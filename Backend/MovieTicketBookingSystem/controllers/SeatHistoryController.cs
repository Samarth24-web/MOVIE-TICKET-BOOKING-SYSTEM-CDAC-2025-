using Microsoft.AspNetCore.Mvc;
using MovieTicketBookingSystem.Services.Interfaces;

namespace MovieTicketBookingSystem.controllers
{
    [ApiController]
    [Route("api/seat-history")]
    public class SeatHistoryController : ControllerBase
    {
        private readonly ISeatHistoryService _historyService;

        public SeatHistoryController(ISeatHistoryService historyService)
        {
            _historyService = historyService;
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetUserSeatHistory(long userId)
        {
            var history = _historyService.GetByUser(userId);
            return Ok(history);
        }

        [HttpGet("show/{showId}")]
        public IActionResult GetShowSeatHistory(long showId)
        {
            var history = _historyService.GetByShow(showId);
            return Ok(history);
        }
    }
}
