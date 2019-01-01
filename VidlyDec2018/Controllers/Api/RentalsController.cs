using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyDec2018.Models;
using VidlyDec2018.Models.Dto;

namespace VidlyDec2018.Controllers.Api
{
    public class RentalsController : ApiController
    {

        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        /*

        //GET api/rentals
        public IEnumerable<RentalDto> GetRentals()
        {
            List<RentalDto> tempDeleteMe = new List<RentalDto>();
            IEnumerable<RentalDto> tempDelMeAgain = tempDeleteMe;
            return tempDelMeAgain;
        }

        //GET api/rentals/1
        public IHttpActionResult GetRental(int id)
        {
            return Ok();
        }
        */

        //POST  api/rental
        [HttpPost]
        public IHttpActionResult CreateRental(RentalDto rental)
        {
            //public apis require extra validation checks like below
            //internal you can use optimistic

            //check to see if any movies have been selected before querying the DB, save time
            if (rental.MovieIds.Count() == 0)
                return BadRequest("No movie Ids have been given");

            //get customer using ID from Dto
            Customer customer = _context.Customers.SingleOrDefault(c => c.Id == rental.CustomerId);
            if (customer == null)
                return BadRequest("CustomerId is not valid");
            //populate list with all Movies using movie IDs from Int list passed in

            
            var movies = _context.Movies.Where(
                    m => rental.MovieIds.Contains(m.Id)
                    
                ).ToList();

            if (movies.Count != rental.MovieIds.Count())
                return BadRequest("At least one movie ID is not valid in the database");

           foreach( Movie mov in movies)
            {
                if (mov.NumberAvailable == 0)
                    return BadRequest(mov.Name + " is not currently available to rent");

                mov.NumberAvailable--;
                Rental temprental = new Rental()
                {
                    Customer = customer,
                    Movie = mov,
                    DateRented = DateTime.Now
                };

                
                _context.Rentals.Add(temprental);
            }
            _context.SaveChanges();

            //doesn't return Created object as multiple things created, not just one
            return Ok();
            
        }

        /*
        public void UpdateRental(int id, RentalDto rental)
        {
            
        }





        //DELETE  api/rental/id
        public IHttpActionResult DeleteRental(int id)
        {
            return Ok();
        }
        */

    }
}
