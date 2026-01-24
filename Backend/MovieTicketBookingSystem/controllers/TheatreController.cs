using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieTicketBookingSystem.Services.Interfaces;

namespace MovieTicketBookingSystem.controllers
{
    [ApiController]
    [Route("api/theatre")]
    public class TheatreController : Controller
    {
        private readonly ITheatreService _service;

        public TheatreController(ITheatreService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            return Ok(_service.GetById(id));
        }

        [HttpGet("Manager/{id}")]
        public IActionResult GetByManegerId(long id)
        {
            return Ok(_service.GetByManagerId(id));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(long id)
        {
            _service.Delete(id);
            return Ok("Theatre deleted");
        }
    }
}
