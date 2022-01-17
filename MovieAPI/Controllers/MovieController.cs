using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Data;
using MovieAPI.Data.DTO_s;
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

        private MovieContext _context;
        private IMapper _mapper;
        public MovieController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] UpdateMovieDTO movieDTO)
        {
            Movie movie = _mapper.Map<Movie>(movieDTO);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetMovie), new {Id = movie.Id}, movie);
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            return Ok(_context.Movies);
        }


        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            Movie movie = _context.Movies.FirstOrDefault(Movie => Movie.Id == id);
            if(movie != null)
            {
                ReadMovieDTO movieDTO = _mapper.Map<ReadMovieDTO>(movie);
                return Ok(movie);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDTO newMovieDTO)
        {
            Movie movie = _context.Movies.FirstOrDefault(Movie => Movie.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            _mapper.Map(newMovieDTO, movie);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            Movie movie = _context.Movies.FirstOrDefault(Movie => Movie.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            _context.Remove(movie);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
