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
        private readonly UserManager<UserTable> _manager;
        private readonly SignInManager<UserTable> _signInManager;
        public AccountController(UserManager<UserTable> userMgr, SignInManager<UserTable> signinMgr)
        {
            _manager = userMgr;
            _signInManager = signinMgr;
        }



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
            await _signInManager.SignOutAsync();
            return Redirect("/");
        }
    }
}
