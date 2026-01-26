using Microsoft.EntityFrameworkCore;
using MovieTicketBookingSystem.Constats;
using MovieTicketBookingSystem.Data;
using MovieTicketBookingSystem.Models;
using MovieTicketBookingSystem.Repository.Interfaces;

namespace MovieTicketBookingSystem.Repository.Implementation
{
    public class BookingRepository : IBookingRepository
    {
        private readonly MovieBookingDbContext _db;

        public BookingRepository(MovieBookingDbContext db)
        {
            _db = db;
        }
        public List<Booking> GetExpiredPendingBookings(DateTime expiryTime)
        {
            return _db.Bookings
                .Where(b =>
                    b.Status == BookingStatus.Pending &&
                    b.CreatedAt <= expiryTime)
                .ToList();
        }
        public Booking Add(Booking booking)
        {
            _db.Bookings.Add(booking);
            _db.SaveChanges();
            return booking;
        }

        public Booking GetById(long bookingId)
        {
            return _db.Bookings
                .First(x => x.BookingId == bookingId);
        }

        public void Update(Booking booking)
        {
            _db.Bookings.Update(booking);
            _db.SaveChanges();
        }

        public void MarkCancelled(long bookingId)
        {
            var booking = _db.Bookings
                .FirstOrDefault(b => b.BookingId == bookingId);

            if (booking == null)
                return;

            booking.Status = BookingStatus.Cancelled;
            booking.CancelledAt = DateTime.UtcNow;

            _db.SaveChanges();
        }

    }
}
