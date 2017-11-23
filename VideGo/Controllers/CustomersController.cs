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
    public class CustomersController : Controller
    {
        // GET: Customers
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes,
            };

            return View(viewModel);
        }

        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            var customerViewModel = new CustomerViewModel
            {
                Customers = customers
            };

            return View(customerViewModel);
        }

        [Route("Customers/Details/{id}")]
        public ActionResult Details( int id )
        {
            var customers = _context.Customers.ToList();

            if (customers.Count < id)
            {
                return HttpNotFound();
            }

            return View(customers.ElementAtOrDefault(id - 1));
        }

    }
}