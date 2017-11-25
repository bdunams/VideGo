using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VideGo.Models
{
    public class Movie : DbContext
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "The Number in Stock must be between 1 and 20.")]
        [Display(Name = "Number In Stock")]
        public int NumberInStock { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
    }

}