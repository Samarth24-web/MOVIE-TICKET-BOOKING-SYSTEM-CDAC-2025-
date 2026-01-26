using Microsoft.AspNetCore.Mvc;
using MovieTicketBookingSystem.DTOs.Booking;
using MovieTicketBookingSystem.Services.Interfaces;

namespace MovieTicketBookingSystem.controllers
{
    [ApiController]
    [Route("api/bookings")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto dto)
        {
            var result = _bookingService.CreateBooking(dto);
            return Ok(result);
        }

        [HttpPost("cancel")]
        public IActionResult CancelBooking(CancelBookingDto dto)
        {
            _bookingService.CancelBooking(dto);
            return Ok(new { Message = "Booking cancelled successfully" });
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetUserBookings(long userId)
        {
            return Ok(_bookingService.GetBookingsByUser(userId));
        }

        [HttpGet("{bookingId}")]
        public IActionResult GetBooking(long bookingId)
        {
            return Ok(_bookingService.GetBookingDetails(bookingId));
        }

    }
}
