using Microsoft.AspNetCore.Mvc;
using MovieTicketBookingSystem.Services.Interfaces;

namespace MovieTicketBookingSystem.controllers
{
    [ApiController]
    [Route("api/seat-types")]
    public class ScreenTypeController : Controller
    {
        private readonly IScreenTypeService _screenTypeService;

        public ScreenTypeController(IScreenTypeService screen)
        {
            _screenTypeService = screen;
        }

        public IActionResult GetAll()
        {
            return Ok(_screenTypeService.GetAll());
        }

    }
}
