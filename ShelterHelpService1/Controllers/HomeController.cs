using Microsoft.AspNetCore.Mvc;

namespace ShelterHelpService1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
