using MovieTicketBookingSystem.DTOs.Booking;
using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.Mappers
{
    public static class BookingMapper
    {
        public static BookingResultDto BookingToBookingResultDto(
            Booking booking,
            string razorpayOrderId)
        {
            return new BookingResultDto
            {
                BookingId = booking.BookingId,
                TotalAmount = booking.TotalAmount,
                RazorpayOrderId = razorpayOrderId
            };
        }
    }
}
