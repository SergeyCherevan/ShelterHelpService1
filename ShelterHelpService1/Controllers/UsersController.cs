using System;
using System.IO;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using ShelterHelpService1.Models;
using ShelterHelpService1.Models.ViewModels;

namespace ShelterHelpService1.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly UserManager<UserTable> _manager;
        private readonly SignInManager<UserTable> _signInManager;
        private readonly IWebHostEnvironment _appEnvironment;
        public UsersController(UserManager<UserTable> userMgr, SignInManager<UserTable> signinMgr, IWebHostEnvironment appEnviroment)
        {
            _manager = userMgr;
            _signInManager = signinMgr;
            _appEnvironment = appEnviroment;
        }

        public async Task<IActionResult> RedactAccount()
        {
            ViewBag.IsAuthenticated = User.Identity.IsAuthenticated;

            ViewBag.AvatarName = (await _manager.FindByNameAsync(User.Identity.Name)).Image;

            User curUser = (await _manager.GetUserAsync(HttpContext.User)).GetUser();

            return View(new RedactAccountViewModel
            { 
                Email = (curUser.LoginStructure as EmailLoginStructure).RegistrationEmail,
                PublicEmail = curUser.PublicEmail,
            });
        }

        [HttpPost]
        public async Task<IActionResult> RedactAccount(RedactAccountViewModel model)
        {
            ViewBag.IsAuthenticated = User.Identity.IsAuthenticated;

            UserTable user; IdentityResult result;
            ViewBag.RedactResult = "";

            if (ModelState.IsValid)
            {
                user = await _manager.FindByNameAsync(User.Identity.Name);

                if (model.NewPassword != null)
                {

                    var _passwordValidator =
                        HttpContext.RequestServices.GetService(typeof(IPasswordValidator<UserTable>)) as IPasswordValidator<UserTable>;
                    var _passwordHasher =
                        HttpContext.RequestServices.GetService(typeof(IPasswordHasher<UserTable>)) as IPasswordHasher<UserTable>;

                    result =
                        await _passwordValidator.ValidateAsync(_manager, user, model.NewPassword);

                    if (result.Succeeded)
                    {
                        user.PasswordHash = _passwordHasher.HashPassword(user, model.NewPassword);
                        await _manager.UpdateAsync(user);

                        ViewBag.RedactResult = (string)ViewBag.RedactResult + "Пароль изменён. ";
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }



                user.Email = model.Email;
                user.PublicEmail = model.PublicEmail;                

                result = await _manager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    ViewBag.RedactResult = (string)ViewBag.RedactResult + "Данные отредактированны. ";
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }



                if (model.Avatar != null)
                {
                    try
                    {
                        string type = model.Avatar.ContentType;
                        string fileName = Guid.NewGuid().ToString() + "." + type[(type.IndexOf('/') + 1)..];

                        using (var fileStream = new FileStream(_appEnvironment.WebRootPath + "/users-avatars/" + fileName, FileMode.Create))
                        {
                            await model.Avatar.CopyToAsync(fileStream);
                        }


                        user.Image = fileName;

                        result = await _manager.UpdateAsync(user);

                        if (!result.Succeeded) throw new ApplicationException("Не удалось загрузить аватарку");


                        ViewBag.AvatarName = fileName;
                        ViewBag.RedactResult = (string)ViewBag.RedactResult + "Аватарка заменена. ";
                    }
                    catch
                    {
                        ModelState.AddModelError(nameof(RedactAccountViewModel.Avatar), "Не удалось загрузить аватарку");
                    }
                }
            }

            return View(model);
        }
    }
}
