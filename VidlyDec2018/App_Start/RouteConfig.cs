using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace VidlyDec2018
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //apply routes from more specific to more generic, going down

            //a better way to add routes than in here which gets messy is to add attributes above the method definition in your controller classes... this is only available in MVC5.. and requires first the next line of code:
            //now use properties above the method in teh controller..
            //... i.e. [Route("movies/released/{year}/{month)}"]
            //or with constraint..
            //...i.e. [Route("movies/released/{year}/{month:regex(\\d{4}): range(1, 12)}"]
            //regex = regular expression
            //raneg can be swapped out with min, max, minlength ... float etc

            routes.MapMvcAttributeRoutes();


            /*
            //example of a custom route
            //the year and month will be passed to the ByReleaseDate method through teh URI
            //@ symbol used as \ cannot be used in URI
            routes.MapRoute(
                "MoviesByReleaseDate",
                "movies/released/{year}/{month}",
                new {controller = "Movies", action = "ByReleaseDate"},
                //bottom is a constraint - ensures year has 4 characters, and month has 2, otherwise - error 404
                //new {year = @"\d{4}", month=@"\d{2}"}
                new { year = @"2015|2016", month = @"\d{2}" });
            //if we refactor the name of a method or controller, these strign literal values will need to be changed by hand... auto refactor doesn't get them

            */
            //where new is without object type, this is called anonymous object


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
