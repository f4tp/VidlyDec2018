using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyDec2018.Models;

namespace VidlyDec2018.ViewModels
{

    //view models are used when a view requires multipel models passign to it
    public class RandomMovieViewModel
    {

        public Movie MovieSet { get; set; }
        public List<Customer> CustomersList { get; set; }
    }
    
}