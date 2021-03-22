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
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private MovieContext context { get; set; }

        public HomeController(MovieContext con)
        {
            context = con;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewMovies()
        {
            return View();
        }

        //This Post saves the user input to temp storage and shows a completion page if the response is validated.
        //Othwerwise it returns the same form view
        [HttpPost]
        public IActionResult NewMovies(MovieModel m)
        {
            if (ModelState.IsValid)
            {
                context.Movies.Add(m);
                context.SaveChanges();
                //TempStorage.AddApplication(appResponse);
                //return View("Movies", appResponse);
                //Response.redirect
                return View("Movies");
            }
            return View("NewMovies");
     

            
        }

        [HttpGet]
        public IActionResult List()
        {
            //return View(TempStorage.Applications.Where(x => x.Title != "Independence Day"));
            return View(context.Movies);
        }

        [HttpPost]
        public IActionResult List(MovieModel m)
        {
            return View("DeleteM", m);
        }

        [HttpGet]
        public IActionResult DeleteM()
        {
            return View();
        }


        [HttpPost]
        public IActionResult DeleteM(MovieModel m)
        {
            context.Movies.Remove(m);
            context.SaveChanges();
            return View("List");
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
