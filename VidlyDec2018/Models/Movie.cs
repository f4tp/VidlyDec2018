using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace VidlyDec2018.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Movie Title")]
        [Required(ErrorMessage = "The movie's name is required")]
        public String Name { get; set; }
        //navigation property
        public Genre Genre { get; set; }
        //naming convention
        [Required(ErrorMessage = "Please select a genre")]
        public int GenreId { get; set; }
        //the above messed up my database
        //I named Id as GenreID in my Genre class, which gave an extra column in the
        //db table called Genre_GenreId... DON'T DO THIS!!!
        //Also, the data type for thsi was different from the data type in eth Genre class... big NO NO!
        //the above is why the extra column I think
        //reverse migration code:
        //Update-Database -TargetMigration:"MugrationNameYouSet"
        [Required(ErrorMessage = "Please update when the movie was released")]
        [Display(Name = "Date Released")]
        public DateTime? ReleaseDate { get; set; }

        //[Required]
        public DateTime? DateAdded { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Please enter a value between 1 and 20")]
        [Range(1,20)]
        [Display(Name = "Number In Stock")]
        public byte NumberInStock { get; set; }

        public byte NumberAvailable { get; set; }



        public Movie()
        {

        }
    }
}

