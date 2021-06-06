using System;
using System.IO;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using ShelterHelpService1.Models;
using ShelterHelpService1.Models.ViewModels;

namespace ShelterHelpService1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<UserTable> _manager;
        private readonly SignInManager<UserTable> _signInManager;
        private readonly IWebHostEnvironment _appEnvironment;
        public AccountController(UserManager<UserTable> userMgr, SignInManager<UserTable> signinMgr, IWebHostEnvironment appEnviroment)
        {
            _manager = userMgr;
            _signInManager = signinMgr;
            _appEnvironment = appEnviroment;
        }



        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await _manager.FindByNameAsync(model.UserName);

                if (user != null)
                {
                    await _signInManager.SignOutAsync();

                    var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);

                    if (result.Succeeded)
                    {
                        return Redirect(returnUrl ?? "/");
                    }
                }

                ModelState.AddModelError(nameof(LoginViewModel.UserName), "Неверный логин или пароль");
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Registration(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Registration(RegistrationViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                UserTable user = new UserTable
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    PublicEmail = model.PublicEmail,
                };

                var result = await _manager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // установка куки
                    await _signInManager.SignInAsync(user, false);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);

                        return View(model);
                    }
                }



                if (model.Avatar != null)
                {
                    try
                    {
                        string type = model.Avatar.ContentType;
                        string fileName = Guid.NewGuid().ToString() + "." + type[(type.IndexOf('/') + 1)..];

                        using (var fileStream = new FileStream(_appEnvironment.WebRootPath + "/users-images/" + fileName, FileMode.Create))
                        {
                            await model.Avatar.CopyToAsync(fileStream);
                        }



                        user.Image = fileName;

                        result = await _manager.UpdateAsync(user);

                        if (!result.Succeeded) throw new ApplicationException("Не удалось загрузить аватарку");
                    }
                    catch
                    {
                        //ModelState.AddModelError(nameof(RegistrationViewModel.Avatar), "Не удалось загрузить аватарку");

                        //return View(model);
                    }
                }                    
                
                
                return Redirect(returnUrl ?? "/");
            }

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/");
        }
    }
}
