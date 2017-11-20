using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideGo.Models;

namespace VideGo.ViewModels
{
    public class CustomerViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
    }
}