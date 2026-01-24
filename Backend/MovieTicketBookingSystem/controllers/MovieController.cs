using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieTicketBookingSystem.DTOs;
using MovieTicketBookingSystem.Services.Implementation;
using MovieTicketBookingSystem.Services.Interfaces;

namespace MovieTicketBookingSystem.controllers
{
    [ApiController]
    [Route("api/movie")]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateMovie([FromForm] CreateMovieDto dto)
        {
            var movieId = await _movieService.CreateMovieAsync(dto);
            return Ok(new { MovieId = movieId });
        }

        [HttpGet]
        [Authorize]
        public List<MovieResponseDto> getAllMovies()
        {
            return _movieService.getAllMovies();
        }

        [HttpGet]
        [Authorize]
        [Route("id/{movieId}")]
        public MovieResponseDto GetMovieById(int movieId)
        {
            return _movieService.getMovieByid(movieId);
        }

        [HttpGet]
        [Authorize]
        [Route("name/{name}")]
        public MovieResponseDto GetMovieByName(string name)
        {
            return _movieService.getMovieBtName(name);
        }

        [HttpGet]
        [Authorize]
        [Route("Latest/{count}")]
        public List<MovieResponseDto> findLatestTrendingMoviesSortByDateAndRating(int count)
        {
            return _movieService.findLatestTrendingMoviesSortByDateAndRating(count);
        }

        [HttpGet]
        [Route("search/{startsWith}")]
        public List<String> findBySearchStartLetters(string startsWith) 
        { 
            return _movieService.findBySearchStartLetters(startsWith);
        }

    }
}
