using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideGo.DTOs;
using VideGo.Models;

namespace VideGo.Controllers.Api
{
    public class RentalController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IHttpActionResult GetRentals(int id)
        {

            var customerRentals = _context.Rentals
                .Include(r => r.Movie)
                .Where(r => r.DateReturned == null)
                .Where(r => r.Customer.Id == id);

            var customerRentalDTO = customerRentals
                .ToList()
                .Select(Mapper.Map<Rental, ReturnDTO>);

            return Ok(customerRentalDTO);
        }

        [HttpPost]
        public IHttpActionResult CreateNewRental(RentalDTO newRental)
        {
            var customer = _context.Customers.Single(
                c => c.Id == newRental.CustomerId);

            var movies = _context.Movies.Where(
                m => newRental.ids.Contains(m.Id)).ToList();

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult ReturnRental(RentalDTO newRental)
        {
            var customer = _context.Customers.Single(
                c => c.Id == newRental.CustomerId);

            if (customer == null)
                return BadRequest();

            var customerRentals = _context.Rentals
                .Include(r => r.Movie)
                .Where(r => r.DateReturned == null)
                .Where(r => newRental.ids.Contains(r.Id));

            foreach (var rental in customerRentals)
            {
                if (rental.Movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                rental.Movie.NumberAvailable++;

                rental.DateReturned = DateTime.Now;

                //var rental = new Rental
                //{
                //    Customer = customer,
                //    Movie = movie,
                //    DateRented = DateTime.Now
                //};

                //_context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
