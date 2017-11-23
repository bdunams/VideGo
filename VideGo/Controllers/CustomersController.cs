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
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes,
            };

            return View(viewName: "CustomerForm", model: viewModel);
        }

        [HttpPost]
        public ActionResult Create(CustomerFormViewModel viewModel)
        {
            _context.Customers.Add(viewModel.Customer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
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

        [Route(@"Customers/Details/{id}")]
        public ActionResult Details( int id )
        {
            var customers = _context.Customers.ToList();

            if (customers.Count < id)
            {
                return HttpNotFound();
            }

            return View(customers.ElementAtOrDefault(id - 1));
        }

        [Route(@"Customers/Edit/{id}")]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View(viewName: "CustomerForm", model: viewModel);
        }
    }
}