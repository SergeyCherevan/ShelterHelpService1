using Microsoft.AspNetCore.Mvc;

namespace ShelterHelpService1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(bool isLoginFormVisible, string loginFormMessage)
        {
            ViewBag.returnUrl = "/";

            ViewBag.isLoginFormVisible = isLoginFormVisible;
            ViewBag.loginFormMessage = loginFormMessage;

            ViewBag.IsAuthenticated = User.Identity.IsAuthenticated;

            return View();
        }
    }
}
