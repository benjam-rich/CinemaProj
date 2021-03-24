using CinemaProj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using CinemaProj.Models.ViewModels;

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
                //return View("Movies");
            }
            return View("List", new MovieViewModel
            {
                Movie = context.Movies.Where(x => x.Title != null)
            });

        }

        [HttpGet]
        public IActionResult List()
        {
            return View(new MovieViewModel
            {
                Movie = context.Movies
            });
        }

        [HttpPost]
        public IActionResult List(int movieId)
        {

            return View("EditMovie", new MovieViewModel
            {
                Movie = context.Movies.Where(x => x.MovieId == movieId),

            }); ;
        }

        [HttpPost]
        public IActionResult MovieDelete(int MovieDeleteId)  //passing in movieID then removing the movie through its id
        {
            var removeMovie = context.Movies.FirstOrDefault(x => x.MovieId == MovieDeleteId);
            context.Movies.Remove(removeMovie);
            context.SaveChanges();
            return View("List", new MovieViewModel
            {
                Movie = context.Movies.Where(x => x.Title != null)
            });
        }

        [HttpPost]
        public IActionResult EditMovie(MovieModel movieForm, int movieIdentity) //passing in the new edited movie and deleting old one
        {
            var removeMovie = context.Movies.FirstOrDefault(x => x.MovieId == movieIdentity);
            context.Movies.Remove(removeMovie);
            context.Movies.Add(movieForm);
            context.SaveChanges();
            return View("List", new MovieViewModel
            {
                Movie = context.Movies.Where(x => x.Title != null)
            });
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
