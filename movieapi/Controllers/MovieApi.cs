using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MovieApi.Models;
using MovieApi.Services;

namespace MovieApi.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MovieController : ControllerBase
    {
        private readonly List<Movie> _movies;
        private IMovieService _service;

        public MovieController(IMovieService service)
        {
            _service = service;
            // Initialize the list of movies
            _movies = new List<Movie>
            {
                new Movie("Citezen Smith", 1941, "Action", 1),
                new Movie("The Warlock of Oz", 1939, "Comedy", 2),
                new Movie("The Grandmother", 1972, "Drama", 3),
            };
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            IEnumerable<Movie> list = _service.GetAll();

            if(list == null)
            {
                // No movies found
                return NotFound();
            }
            return Ok(list);
        }

        [HttpGet("{name}", Name = "GetMovieByName")]
        public IActionResult GetMovieByName(string name)
        {
            Movie movie = _service.GetMovieByName(name);

            // Find the movie with the specified id
            // var movie = _movies.Find(m => m.Title == name);

            if (movie == null)
            {
                // Movie not found
                return NotFound();
            }

            // Return the movie
            return Ok(movie);
        }

        [HttpGet("/year/{year}")]
        public IActionResult GetMoviesByYear(int year)
        {
            IEnumerable<Movie> moviesbyyear = _service.GetMoviesByYear(year);
            // Find the movie with the specified year
            //var movie = _movies.Find(m => m.Year == year);

            if (moviesbyyear == null)
            {
                // Movie not found
                return NotFound();
            }

            // Return the movie
            return Ok(moviesbyyear);
        }

        [HttpPost]
        public IActionResult CreateMovie(Movie m)
        {
            try {
            // Add the movie to the list
                //_movies.Add(m);
                _service.InsertMovie(m);
                return CreatedAtRoute("GetMovieByName", new { name = m.Title }, m);
           } 
            catch {
               return BadRequest();
        }

    }

        [HttpPut("{name}")]
        public IActionResult UpdateMovie(string name,Movie moviein)
        {
            
            try 
            {
                _service.UpdateMovie(moviein);
            // Find the movie with the specified id
                // foreach (Movie m in _movies)
                // {
                //     if (m.Title == name)
                //     {
                //         m.Title = moviein.Title;
                //         m.Year = moviein.Year;
                //         m.Genre = moviein.Genre;
                //         return NoContent();
                //     }
                // }
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }

        }

        [HttpDelete("{name}")]
        public IActionResult DeleteMovie(Movie name)
        {
            try
            {
                _service.DeleteMovie(name);
                // Find the movie with the specified id
                // foreach (Movie m in _movies)
                // {
                //     if (m.Title == name)
                //     {
                //         _movies.Remove(m);
                //         return NoContent();
                //     }
                // }
                // return BadRequest();
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }

        }
    }
    }