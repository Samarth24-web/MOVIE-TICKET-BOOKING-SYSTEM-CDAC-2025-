using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieTicketBookingSystem.Models;
using MovieTicketBookingSystem.Services.Interfaces;

namespace MovieTicketBookingSystem.controllers
{
    [ApiController]
    [Route("api/screens")]
    [Authorize(Roles = "TheatreManager")]
    public class ScreenController : ControllerBase
    {
        private readonly IScreenService _screenService;

        public ScreenController(IScreenService screenService)
        {
            _screenService = screenService;
        }

        // POST /api/screens
        [HttpPost]
        public IActionResult Create([FromBody] Screen screen)
        {
            var created = _screenService.CreateScreen(screen);
            return Ok(created);
        }

        // GET /api/screens/by-theatre/{theatreId}
        [HttpGet("by-theatre/{theatreId}")]
        public IActionResult GetByTheatre(long theatreId)
        {
            return Ok(_screenService.GetScreensByTheatre(theatreId));
        }

        // PUT /api/screens/{id}
        [HttpPut("{id}/{ScreenName}")]
        public IActionResult Update(long id, string ScreenName)
        {
            _screenService.UpdateScreen(id, ScreenName);
            return Ok("Screen updated");
        }

        // DELETE /api/screens/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _screenService.DeleteScreen(id);
            return Ok("Screen deleted");
        }
    }


}
