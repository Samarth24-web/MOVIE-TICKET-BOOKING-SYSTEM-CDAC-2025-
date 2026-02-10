using Microsoft.AspNetCore.Mvc;
using MovieTicketBookingSystem.DTOs.Show;
using MovieTicketBookingSystem.Services.Implementation;
using MovieTicketBookingSystem.Services.Interfaces;

namespace MovieTicketBookingSystem.controllers
{
    [ApiController]
    [Route("api/shows")]
    public class ShowController : ControllerBase
    {
        private readonly IShowService _service;

        public ShowController(IShowService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult RegisterShow(CreateShowDto dto)
        {
            return Ok(_service.RegisterShow(dto));
        }

        [HttpGet("{showId}/seats")]
        public IActionResult GetSeatLayout(long showId)
        {
            return Ok(_service.GetSeatLayout(showId));
        }

        [HttpGet("past/{managerId}")]
        public IActionResult PastShows(long managerId)
        {
            return Ok(_service.GetPastShows(managerId));
        }

        [HttpGet("upcoming/{managerId}")]
        public IActionResult UpcomingShows(long managerId)
        {
            return Ok(_service.GetUpcomingShows(managerId));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            return Ok(_service.GetById(id));
        }

        [HttpGet("{city}/{movieId}/{date}")]
        public IActionResult GetShowsByCityMovieDate(
           string city,
           long movieId,
           DateTime date)
        {
            var result = _service
                .GetShowsByCityMovieDate(city, movieId, date);

            return Ok(result);
        }

    }

}
