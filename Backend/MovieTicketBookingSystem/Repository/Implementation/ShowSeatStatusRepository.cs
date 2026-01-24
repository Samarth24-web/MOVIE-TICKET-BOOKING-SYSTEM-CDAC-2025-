using Microsoft.EntityFrameworkCore;
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
    }

}
