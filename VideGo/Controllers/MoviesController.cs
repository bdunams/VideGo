using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideGo.Models;
using VideGo.ViewModels;

namespace VideGo.Controllers
{
    public class MoviesController : Controller
    {
        public List<Movie> Movies { get; set; }
        // GET: Movies

        public ActionResult Index()
        {
            var movies = new List<Movie>
            {
                new Movie { Title = "Alien: Covenant", Id = 0 },
                new Movie { Title = "The Last Samurai", Id = 1 }
            };

            var movieModel = new MovieViewModel
            {
                Movies = movies
            };

            return View(movieModel);
        }

        public ActionResult Random()
        {


            var movie = new Movie() { Title = "Alien: Covenant" };

            var viewModel = new MovieViewModel
            {
                Movie = movie
            };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("id = " + id);
        }

        

        [Route("movies/released/{year}/{month}")]
        public ActionResult byReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}