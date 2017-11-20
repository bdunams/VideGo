using System;
using System.Collections.Generic;
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
        public List<Customer> customers { get; set; }

        public ActionResult Index()
        {
            customers = new List<Customer>
            {
                new Customer { Name = "Brian" , Id = 0 },
                new Customer { Name = "Todd" , Id = 1 }
            };

            var customerViewModel = new CustomerViewModel
            {
                Customers = customers
            };

            return View(customerViewModel);
        }

        [Route("Customers/Details/{id}")]
        public ActionResult Details( int id )
        {
            customers = new List<Customer>
            {
                new Customer { Name = "Brian" , Id = 0 },
                new Customer { Name = "Todd" , Id = 1 }
            };

            if (customers.Count <= id)
                return HttpNotFound();

            return View(customers.ElementAtOrDefault(id));
        }
    }
}