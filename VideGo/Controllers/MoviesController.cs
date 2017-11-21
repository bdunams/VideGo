using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            var movieModel = new MovieViewModel
            {
                Movies = movies
            };

            return View(movieModel);
        }

        [Route("Movies/Details/{id}")]
        public ActionResult Details( int id )
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            if (movies.Count < id || id < 1)
            {
                return HttpNotFound();
            }

            return View(movies.ElementAtOrDefault(id - 1));
        }

        

        [Route("movies/released/{year}/{month}")]
        public ActionResult byReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}