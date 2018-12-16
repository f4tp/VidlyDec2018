using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using VidlyDec2018.Models;
using VidlyDec2018.ViewModels;


namespace VidlyDec2018.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;

        //ctor
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //needed to dispose of DB connection
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        //[Route("Movies/AllMovies")]
        public ActionResult Index()
        {

            var movis = _context.Movies.Include(m => m.Genre).ToList();
            return View(movis);
            //return View();
            

            /*
            Movie movIn = new Movie
            {
                Id = 1,
                Name = "HeMan"
            };

            Movie movIn2 = new Movie
            {
                Id = 2,
                Name = "Skeletor"
            };

            List<Movie> tempMovs = new List<Movie>
            {
                movIn,
                movIn2
            };

            var viewMod = new ViewModels.AllMoviesViewModel
            {
                AllMovies = tempMovs
            };
            
            return View(viewMod);
            */
        }

        public ActionResult Details(int id)
        {
            //singleOrDefautl also queries database immediately, not in iterator in view
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }


        // GET: Movies/Random
        public ActionResult Random()
        {
            var ranMovie = new Movie() {Name = "Shrek!", Id = 1};


            //return Content("Hello World"); //overwrites content
            //return HttpNotFound("not found error here"); //standard http 404 error screen
            // return new EmptyResult(); //responds with an empty result
            //underneath


            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name"}); // the new {} you chain paramters in here which appear in the URI

            //METHOD 1 - CALL - old way
            //return View(ranMovie); //passes Movie Model to view

            //METHOD 2 - CALL - another way of passign data to the view     
            //ViewData["Movie"] = ranMovie;
            //return View();

            //METHOD 3 - CALL - a better way using ViewBag
            //ViewBag.Movie = ranMovie;
            //return View();

            //the ranMovie object will be held in... 
            //var viewResult = new ViewResult();
            //... viewResult.ViewData.Model
            //var databeignPassedToView = viewResult.ViewData.Model;
            //ViewData is a ViewData dictionary, not a regular dictionary#
            //var ranMovie = new Movie() { Name = "Shrek!", Id = 1 };
            //return View(ranMovie);

            
            var customers = new List<Customer>
            {
                new Customer{Name = "Customer 1"},
                new Customer{Name = "Customer 2"}
            };

            var viewModelMoviesCusts = new RandomMovieViewModel
            {
                MovieSet = ranMovie,
                CustomersList = customers
            };
            
            return View(viewModelMoviesCusts);

        
    }

        //ID passed in through URI /controller/method/param
        //can also be passed in as movies/edit?id=1
        //id here matters as it is a part of the default route ruling system
        public ActionResult Edit(int id) 
        {
            return Content("id=" + id); 
        }

        //movies
        //to make a parameter optional, you make it nullable... with the ?
        //sortBy is a string type = reference type = already nullable
        //if index is called with no params, it can still be called...
        //this routine sorts the state of the objects to format the strinmg for the URI
        //would be called e.g. Movies?pageIndex=5&sortBy=Date


            /*
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (string.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            return Content(String.Format("pageIndex={0}&sortby={1}", pageIndex, sortBy));
        }
        */

        //mvcaction4 - tab - code snippet for Action Result... doesn't work
        //44mins in vid to get this route
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        //regex aplies a regular expression?... a function that we call
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        } 

        
        
    }
}