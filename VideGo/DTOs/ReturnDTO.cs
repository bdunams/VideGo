using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideGo.DTOs
{
    public class ReturnDTO
    {
        public int Id { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }

        public CustomerDTO Customer { get; set; }

        public MovieDTO Movie { get; set; }
    }
}