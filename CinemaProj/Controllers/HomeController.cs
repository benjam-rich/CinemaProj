using CinemaProj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CinemaProj.Controllers
    /*This page controls what vies will display and what information is passed to each view. Very useful */
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

        [HttpGet]
        public IActionResult newMovies()
        {
            return View();
        }

        [HttpPost]
        public IActionResult newMovies(ApplicationResponse appResponse)
        {
            TempStorage.AddApplication(appResponse);
            return View("Movies", appResponse);
        }

        //This Action will display all the responses in temporary storage to the Movie List page as long as they're not Indendence Day
        public IActionResult List()
        {
            return View(TempStorage.Applications.Where(x => x.Title != "Independence Day"));
        }
        public IActionResult Podcasts()
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
    }
}
