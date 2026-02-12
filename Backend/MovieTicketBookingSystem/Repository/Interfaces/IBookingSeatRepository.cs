using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.Repository.Interfaces
{
    public interface IBookingSeatRepository
    {
        void AddRange(List<BookingSeat> bookingSeats);
        List<BookingSeat> GetByBookingId(long bookingId);
    }
}
