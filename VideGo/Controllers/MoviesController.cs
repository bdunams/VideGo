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

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Movie = new Movie(),
                Genres = genres
            };

            return View(viewName: "MovieForm", model: viewModel);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };

                return View(viewName: "MovieForm", model: viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Title = movie.Title;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.DateAdded = DateTime.Now;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View(viewName: "MovieForm", model: viewModel);
        }
    }
}