using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyDec2018.Models;
using VidlyDec2018.Models.Dto;

namespace VidlyDec2018.Controllers.Api
{
    //below only lets Admin users pull in data, view is generated and customer can see it but cannot pull data across
    //[Authorize(Roles = RoleName.CanManageMovies)]
    public class MoviesController : ApiController
    {

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //  GET /api/movies
        public IEnumerable<MovieDto> GetMovies(string query = null)
        {
            //old one for MVC rather than API, does not eager load
            //return _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
            //only fetching and displaying movies in stock now as NumberAvailable > 0 added
            var moviesquery = _context.Movies
                .Include(m => m.Genre)
                .Where(m => m.NumberAvailable > 0);
            if (!String.IsNullOrWhiteSpace(query))
                moviesquery = moviesquery.Where(m => m.Name.Contains(query));
            

            var moviesDto = moviesquery
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);

            return moviesDto;
        }

        //  GET api/movies/1
        public IHttpActionResult GetMovie (int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Mapper.Map<Movie, MovieDto>(movie));
            }
        }


        [HttpPost]
        //  POST /api/movie
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var movie = Mapper.Map<MovieDto, Movie>(movieDto);
                _context.Movies.Add(movie);
                _context.SaveChanges();
                movieDto.Id = movie.Id;
                return Created(new Uri(Request.RequestUri.AbsoluteUri + "/" + movie.Id), movieDto);
            }
        }


        //  PUT / api/customers/1
        [HttpPut]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
                if (movieInDb == null)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
                else
                {
                    Mapper.Map(movieDto, movieInDb);
                    _context.SaveChanges();
                }
            }
        }

        //  DELETE api/movies/1
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                _context.Movies.Remove(movieInDb);
                _context.SaveChanges();
            }
        }


    }
}
