using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyDec2018.Models;
using System.ComponentModel.DataAnnotations;

namespace VidlyDec2018.ViewModels.Movies
{
    //viewmodel because New customer view needs customer and membershiptypes object
    public class MovieFormViewModel
    {
        //IEnumrable - allows iteration, but doesnt have add / contains methods etc
        public List<Genre> Genres { get; set; }


        //gettign rid of movie object, and providing individual properties instead, just teh ones that teh form needs
        //public Movie Movie { get; set;}
        //might not be needed
        // public List<Movie> Movies { get; set; }

       
        public int? Id { get; set; }
        
        [Required]
        public String Name { get; set; }
        [Required]
        public int? GenreId { get; set; }
        [Display(Name = "Date Released")]
        public DateTime? ReleaseDate { get; set; }
        [Required]
        [Display(Name = "Number In Stock")]
        public byte? NumberInStock { get; set; }


        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            NumberInStock = movie.NumberInStock;
            ReleaseDate = movie.ReleaseDate;
            GenreId = movie.GenreId;

        }

        public MovieFormViewModel()
        {
            this.Id = 0;
        }





    }
}