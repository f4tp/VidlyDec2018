using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyDec2018.Models.Dto
{
    public class MovieDto
    {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "The movie's name is required")]
        public String Name { get; set; }
        //public Genre Genre { get; set; }

        public GenreDto Genre { get; set; }
        [Required(ErrorMessage = "Please select a genre")]
        public int GenreId { get; set; }
        [Required(ErrorMessage = "Please update when the movie was released")]
        public DateTime? ReleaseDate { get; set; }
        public DateTime? DateAdded { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Please enter a value between 1 and 20")]
        public byte NumberInStock { get; set; }




    }
}