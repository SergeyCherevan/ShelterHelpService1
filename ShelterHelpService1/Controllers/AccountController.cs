using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using ShelterHelpService1.Models;
using ShelterHelpService1.Models.ViewModels;

namespace ShelterHelpService1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _manager;
        private readonly SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userMgr, SignInManager<User> signinMgr)
        {
            _manager = userMgr;
            _signInManager = signinMgr;
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
                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                    {
                        return Redirect(returnUrl ?? "/");
                    }
                }
                ModelState.AddModelError(nameof(LoginViewModel.UserName), "Неверный логин или пароль");
            }

            return Redirect( (returnUrl ?? "/") + "?isLoginFormVisible=true&loginFormMessage=Неверный логин или пароль");
        }

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
                User user = new User
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
                    return Redirect(returnUrl ?? "/");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            Response.Cookies.Delete("myUser");

            await _signInManager.SignOutAsync();
            return Redirect("/");
        }
    }
}
