using Microsoft.AspNetCore.Mvc;

using ShelterHelpService1.Settings;

namespace ShelterHelpService1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Timeline(bool isLoginFormVisible, string loginFormMessage)
        {
            ViewBag.returnUrl = "/";

            ViewBag.IsAuthenticated = User.Identity.IsAuthenticated;

            return View();
        }
    }
}
