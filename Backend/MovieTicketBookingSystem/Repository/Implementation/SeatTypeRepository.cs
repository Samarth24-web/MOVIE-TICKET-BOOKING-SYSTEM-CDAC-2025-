using MovieTicketBookingSystem.Data;
using MovieTicketBookingSystem.Models;
using MovieTicketBookingSystem.Repository.Interfaces;

namespace MovieTicketBookingSystem.Repository.Implementation
{
    public class SeatTypeRepository : ISeatTypeRepository
    {
        private readonly MovieBookingDbContext _context;

        public SeatTypeRepository(MovieBookingDbContext context)
        {
            _context = context;
        }

        public List<SeatType> GetAll()
        {
            return _context.SeatTypes.ToList();
        }
    }
}
