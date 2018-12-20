using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyDec2018.Models;

namespace VidlyDec2018.ViewModels.Movies
{
    //viewmodel because New customer view needs customer and membershiptypes object
    public class MovieFormViewModel
    {
        //IEnumrable - allows iteration, but doesnt have add / contains methods etc
        public List<Genre> Genres { get; set; }
        public Movie Movie { get; set;}
        //might not be needed
       // public List<Movie> Movies { get; set; }
        

        


       
    }
}