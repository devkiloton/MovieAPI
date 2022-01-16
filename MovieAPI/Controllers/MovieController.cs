using Microsoft.AspNetCore.Mvc;
using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private static List<Movie> movies = new List<Movie>();
        private static int id;

        [HttpPost]
        public IActionResult AddMovie([FromBody]Movie movie)
        {
            movie.Id = id++;
            movies.Add(movie);
            return CreatedAtAction(nameof(GetMovie), new {Id = movie.Id}, movie);
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            return Ok(movies);
        }


        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            Movie movie = movies.FirstOrDefault(Movie => Movie.Id == id);
            if(movie != null)
            {
                return Ok(movie);
            }
            return NotFound();
        }
    }
}
