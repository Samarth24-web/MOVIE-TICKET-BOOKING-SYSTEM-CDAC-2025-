using Microsoft.EntityFrameworkCore;
using MovieTicketBookingSystem.Constats;
using MovieTicketBookingSystem.Data;
using MovieTicketBookingSystem.Models;
using MovieTicketBookingSystem.Repository.Interfaces;

namespace MovieTicketBookingSystem.Repository.Implementation
{
    public class ShowSeatStatusRepository : IShowSeatStatusRepository
    {
        private readonly MovieBookingDbContext _context;

        public ShowSeatStatusRepository(MovieBookingDbContext context)
        {
            _context = context;
        }

        public void AddRange(List<ShowSeatStatus> statuses)
        {
            _context.ShowSeatStatuses.AddRange(statuses);
            _context.SaveChanges();
        }

        public List<ShowSeatStatus> GetByIds(List<long> showSeatStatusIds)
        {
            return _context.ShowSeatStatuses.Include(s => s.Seat)
                .Where(x => showSeatStatusIds.Contains(x.ShowSeatStatusId))
                .ToList();
        }

        public List<ShowSeatStatus> GetByShow(long showId)
        {
            return _context.ShowSeatStatuses
                .Include(s => s.Seat)
                    .ThenInclude(seat => seat.SeatRow)
                .Where(s =>
                    s.ShowId == showId &&
                    s.IsActive)
                .ToList();
        }

        public void UpdateRange(List<ShowSeatStatus> seats)
        {
            _context.ShowSeatStatuses.UpdateRange(seats);
            _context.SaveChanges();
        }
    public List<ShowSeatStatus> GetExpiredLockedSeats(DateTime currentTime)
        {
            return _context.ShowSeatStatuses.Include(s => s.Seat)
                .Where(s =>
                    s.Status == SeatStatus.Locked &&
                    s.LockExpiryTime != null &&
                    s.LockExpiryTime <= currentTime)
                .ToList();
        }

        public List<ShowSeatStatus> GetSeatsByBookingId(long bookingId)
        {
            return _context.ShowSeatStatuses.Include(s => s.Seat)
                .Where(s => s.BookingId == bookingId)
                .ToList();
        }

        public void Update(ShowSeatStatus seatStatus)
        {
            _context.ShowSeatStatuses.Update(seatStatus);
            _context.SaveChanges();
        }

    }
}
