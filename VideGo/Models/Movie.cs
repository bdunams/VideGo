using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VideGo.Models
{
    public class Movie : DbContext
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    // /movies/random
}