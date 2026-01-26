using Microsoft.AspNetCore.Mvc;
using MovieTicketBookingSystem.Services.Interfaces;

namespace MovieTicketBookingSystem.controllers
{
    [ApiController]
    [Route("api/seat-types")]
    public class SeatTypeController : Controller
    {
        private readonly ISeatTypeService _seatTypeService;

        public SeatTypeController(ISeatTypeService seatTypeService)
        {
            _seatTypeService = seatTypeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_seatTypeService.GetAll());
        }
    }
}
