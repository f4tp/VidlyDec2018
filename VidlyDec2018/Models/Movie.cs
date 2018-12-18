using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace VidlyDec2018.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Display(Name="Movie Title")]
        public String Name { get; set; }
        //navigation property
        public Genre Genre { get; set; }
        //naming convention
        public int GenreId { get; set; }
        //the above messed up my database
        //I named Id as GenreID in my Genre class, which gave an extra column in the
        //db table called Genre_GenreId... DON'T DO THIS!!!
        //Also, the data type for thsi was different from the data type in eth Genre class... big NO NO!
        //the above is why teh extra column I think
        //reverse migration code:
        //Update-Database -TargetMigration:"MugrationNameYouSet"

        [Display(Name = "Date Released")]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }
        [Display(Name = "Nuber In Stock")]
        public byte NumberInStock { get; set; }



        public Movie()
        {

        }
    }
}

