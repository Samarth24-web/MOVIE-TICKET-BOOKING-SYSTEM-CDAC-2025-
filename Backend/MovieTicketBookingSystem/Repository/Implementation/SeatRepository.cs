using Microsoft.EntityFrameworkCore;
using MovieTicketBookingSystem.Data;
using MovieTicketBookingSystem.Models;
using MovieTicketBookingSystem.Repository.Interfaces;

namespace MovieTicketBookingSystem.Repository.Implementation
{
    public class SeatRepository : ISeatRepository
    {
        private readonly MovieBookingDbContext _context;

        public SeatRepository(MovieBookingDbContext context)
        {
            _context = context;
        }

        public List<Seat> GetSeatsByScreen(long screenId)
        {
            return _context.Seats
                .Include(s => s.SeatRow)
                .Where(s => s.SeatRow.ScreenId == screenId)
                .ToList();
        }
    }

}
