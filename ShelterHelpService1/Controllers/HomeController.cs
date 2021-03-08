using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ShelterHelpService1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Footer()
        {
            return View();
        }
    }
}
