using MovieTicketBookingSystem.Data;
using MovieTicketBookingSystem.Models;
using MovieTicketBookingSystem.Repository.Interfaces;

namespace MovieTicketBookingSystem.Repository.Implementation
{
    public class BookingSeatRepository : IBookingSeatRepository
    {
        private readonly MovieBookingDbContext _db;

        public BookingSeatRepository(MovieBookingDbContext db)
        {
            _db = db;
        }

        public void AddRange(List<BookingSeat> bookingSeats)
        {
            _db.BookingSeats.AddRange(bookingSeats);
            _db.SaveChanges();
        }

        public List<BookingSeat> GetByBookingId(long bookingId)
        {
            return _db.BookingSeats
                .Where(x => x.BookingId == bookingId)
                .ToList();
        }
    }
}
