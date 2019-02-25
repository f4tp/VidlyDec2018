using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using VidlyDec2018.Models;
using VidlyDec2018.ViewModels;
using VidlyDec2018.ViewModels.Movies;


namespace VidlyDec2018.Controllers
{
   // [Authorize(Roles = RoleName.CanManageMovies)]
   //[AllowAnonymous]
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
        //[AllowAnonymous]
        public ActionResult Index()
        {
            //the index page is now populated by making a call to the API, rather than using the MVC variant
            //var movies = _context.Movies.Include(m => m.Genre).ToList();
            //return View(movies);

            //edited for roles
            /*
            if (User.IsInRole("CanManageMovies"))
            {
                return View("List");
            }
            else
            {
                return View("ReadOnlyList");
            }
            */

            //below is how we return views based on roles - 

            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");

            return View("ReadOnlyList");



            //return View();

            

           
        }

        //[Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            Movie movie = new Movie();
            var genres = _context.Genres.ToList();
            var viewModel = new ViewModels.Movies.MovieFormViewModel(movie)
            {
               
               //Movie = new Movie(),
                //Id = Movie.Id,
                //Name
                Genres = genres
            };
            return View("MovieForm", viewModel);

           
        }

        #region comments
        //this object posted in has to be called movie, changing it breaks it - gives null object
        //I think the object in teh viewmodel, the form, and the object passed in must be teh same as teh object name - e.g. Movie movie all the way through
        //have a look in the Post request to see details
        #endregion
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save (Movie movie)
        {
            if (!ModelState.IsValid)
            {

                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList(),
                    //Movie = movie
                };
                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                movie.NumberAvailable = movie.NumberInStock;
                _context.Movies.Add(movie);
                
            }
            else
            {
                var movieInDB = _context.Movies.Single(c => c.Id == movie.Id);

                movieInDB.Name = movie.Name;
                movieInDB.NumberInStock = movie.NumberInStock;
                

                movieInDB.GenreId = movie.GenreId;
                //Genre object is not in the DB, only the ID
                //movieInDB.Genre = moviein.Genre;

                movieInDB.DateAdded = movie.DateAdded;
                movieInDB.ReleaseDate = movie.ReleaseDate;
            }

           
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");

            #region comments

            /*
            if (movieViewModelIn.SingleMovie.Id == 0)
            {
                movieViewModelIn.SingleMovie.DateAdded = DateTime.Now;
                _context.Movies.Add(movieViewModelIn.SingleMovie);
            }

            return View("Index", movieViewModelIn);
            */


            /*
            //issues - date for release data sent back is a different data type - DateTimeToDateTime2
            //issues - date for data added sent back is a different data type - DateTimeToDateTime2
            //Movie Name is null when it is stored into the database
            //Number in stock is also null, initilaising with 0
            //movie.DateAdded = DateTime.Now;
            //movie.ReleaseDate = DateTime.Now;
            moviein.GenreId = 1;
            //moviein.Name = "This is tester";
         

            if (moviein.Id == 0)
            {
                moviein.DateAdded = DateTime.Now;
                _context.Movies.Add(moviein);
            }
            else
            {
                //Question - how does Genre get set when only ID is set?
                //there is a Genre object composed in the Movie class...
                //my guess is the get / set method on here auto updates it... find out
                //Console.WriteLine(moviein.Name);
                var movieInDB = _context.Movies.Single(m => m.Id == moviein.Id);
                movieInDB.Name = moviein.Name;
                movieInDB.GenreId = moviein.GenreId;
                movieInDB.ReleaseDate = moviein.ReleaseDate;
                //movieInDB.DateAdded = moviein.DateAdded;
                movieInDB.NumberInStock = moviein.NumberInStock;
            }
                       
            try
            {
                _context.SaveChanges();
            }
            //need using System.Data.Entity.Validation; for the below
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e.ToString());
            }
            
            return RedirectToAction("Index", "Movies");

            /*
        }

        

        //old edit method

        /*
        //ID passed in through URI /controller/method/param
        //can also be passed in as movies/edit?id=1
        //id here matters as it is a part of the default route ruling system
        public ActionResult Edit(int id) 
        {
            return Content("id=" + id); 
             */
            #endregion
        }



        public ActionResult Edit(int id)
        {

            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new ViewModels.Movies.MovieFormViewModel(movie)
            {
                //Movie = movie,
               

                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }



        public ActionResult Details(int id)
        {
            //singleOrDefautl also queries database immediately, not in iterator in view... which accesses the database as and when, thud, it is eager loading
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

            #region comments
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

            #endregion
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

  

        #region comments
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
        #endregion

        #region methodnotneeded
        //mvcaction4 - tab - code snippet for Action Result... doesn't work
        //44mins in vid to get this route
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        //regex aplies a regular expression?... a function that we call
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
        #endregion


    }
}