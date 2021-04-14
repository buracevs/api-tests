using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult FormExample()
        {
            SimpleSearchForView ss = new SimpleSearchForView
            {
                Categories = new List<SelectListItem>
                {
                    new SelectListItem{ Text="Laptops", Value ="laptop"},
                    new SelectListItem{ Text="Phones", Value ="phones"},
                    new SelectListItem{ Text="Consoles", Value ="console"}
                }
            };
            return View(ss);
        }

        [HttpGet]
        public IActionResult Search(SimpleSearchToGet search)
        {
            if(search == null)
            {
                throw new ArgumentException("No Data");
            }
            return View(search);
        }
    }
}
