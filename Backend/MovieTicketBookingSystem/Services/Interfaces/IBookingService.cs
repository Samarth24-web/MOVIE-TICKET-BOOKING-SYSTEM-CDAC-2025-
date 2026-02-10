using MovieTicketBookingSystem.DTOs.Booking;

namespace MovieTicketBookingSystem.Services.Interfaces
{
    public interface IBookingService
    {
        BookingResultDto CreateBooking(CreateBookingDto dto);
        void CancelBooking(CancelBookingDto dto);
        List<object> GetBookingsByUser(long userId);
        object GetBookingDetails(long bookingId);

    }
}
