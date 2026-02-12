using MovieTicketBookingSystem.Data;
using MovieTicketBookingSystem.Models;
using MovieTicketBookingSystem.Repository.Interfaces;

namespace MovieTicketBookingSystem.Repository.Implementation
{
    public class ScreenTypeRepository :IScreenTypeRepository
    {
        private readonly MovieBookingDbContext _context;

        public ScreenTypeRepository(MovieBookingDbContext context)
        {
            _context = context;
        }

        public List<ScreenType> GetAll()
        {
            return _context.ScreenTypes.ToList();
        }
    }
}
