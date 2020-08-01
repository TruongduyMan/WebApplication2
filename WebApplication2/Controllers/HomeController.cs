using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ABC()
        {
            ViewBag.TenTrungTam = "Nhat Nghe";
            ViewData["Phone number"] = 4579348534;
            ViewData["Email"] = "Turn@gmail.com";
            return View();
        }

        public IActionResult Demo()
        {
            ViewBag.ABC = "ABC XYZ";
            TempData["Ho ten"] = "Nhat Nghe";
            return RedirectToAction(actionName:"Show");
        }

        public IActionResult Show()
        {
            var abc = ViewBag.ABC;
            var hoten = TempData["Ho ten"];
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
