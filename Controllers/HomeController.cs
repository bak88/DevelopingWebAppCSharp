using DevelopingWebAppCSharp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DevelopingWebAppCSharp.Controllers
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
            this.ViewData["Text"] = "Not Bad";
            return View();
        }

        public IActionResult HelloBro()
        {            
            return Content("Hello Bro");
        }
        
        public IActionResult Exception()
        {
            throw new Exception("Hi! Im Error");
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

        public IActionResult ErrorProduction()
        {
            return Content("Error pls call us");
        }
    }
}
