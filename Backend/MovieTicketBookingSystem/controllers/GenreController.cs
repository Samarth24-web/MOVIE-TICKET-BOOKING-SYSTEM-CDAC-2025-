using Microsoft.AspNetCore.Mvc;
using MovieTicketBookingSystem.Services.Implementation;
using MovieTicketBookingSystem.Services.Interfaces;

namespace MovieTicketBookingSystem.controllers
{
    public class GenreController : Controller
    {

        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_genreService.GetAll());
        }

    }
}
