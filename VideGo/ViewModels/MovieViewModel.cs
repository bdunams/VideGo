using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideGo.Models;

namespace VideGo.ViewModels
{
    public class MovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Movie> Movies { get; set; }
    }
}