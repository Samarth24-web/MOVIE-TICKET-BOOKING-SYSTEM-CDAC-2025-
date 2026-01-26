using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.Repository.Interfaces
{
    public interface IBookingRepository
    {
        Booking Add(Booking booking);
        Booking GetById(long bookingId);
        void Update(Booking booking);
        List<Booking> GetExpiredPendingBookings(DateTime expiryTime);
        void MarkCancelled(long bookingId);
        List<Booking> GetBookingsByUser(long userId);
        Booking GetBookingDetails(long bookingId);
    }
}
