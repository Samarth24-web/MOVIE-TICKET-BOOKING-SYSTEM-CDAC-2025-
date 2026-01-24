using Microsoft.AspNetCore.Mvc;
using MovieTicketBookingSystem.DTOs;
using MovieTicketBookingSystem.Services.Interfaces;

namespace MovieTicketBookingSystem.controllers
{
    [ApiController]
    [Route("api/seat-rows")]
    public class SeatRowController : ControllerBase
    {
        private readonly ISeatRowService _service;

        public SeatRowController(ISeatRowService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult CreateSeatRow(CreateSeatRowDto dto)
        {
            return Ok(_service.CreateSeatRow(dto));
        }

        [HttpPut("{seatRowId}/row-name/{rowName}")]
        public IActionResult UpdateRowName(long seatRowId, string rowName)
        {
            return Ok(_service.UpdateSeatRowName(seatRowId, rowName));
        }

        [HttpPost("{seatRowId}/seats")]
        public IActionResult AddSeat(long seatRowId, SeatDto dto)
        {
            return Ok(_service.AddSeat(seatRowId, dto));
        }

        [HttpPut("{seatRowId}/seats/{seatId}")]
        public IActionResult UpdateSeat(long seatRowId, long seatId, SeatDto dto)
        {
            return Ok(_service.UpdateSeat(seatRowId, seatId, dto));
        }

        [HttpDelete("{seatRowId}/seats/{seatId}")]
        public IActionResult DeleteSeat(long seatRowId, long seatId)
        {
            _service.DeleteSeat(seatRowId, seatId);
            return Ok();
        }

        [HttpGet("screen/{screenId}")]
        public IActionResult GetSeatRowsByScreen(long screenId)
        {
            return Ok(_service.GetSeatRowsByScreen(screenId));
        }
    }

}
