using MovieTicketBookingSystem.DTOs.Booking;

namespace MovieTicketBookingSystem.Services.Interfaces
{
    public interface IBookingService
    {
        BookingResultDto CreateBooking(CreateBookingDto dto);
        void CancelBooking(CancelBookingDto dto);
    }
}
