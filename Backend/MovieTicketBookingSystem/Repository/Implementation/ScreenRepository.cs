using Microsoft.EntityFrameworkCore;
using MovieTicketBookingSystem.Data;
using MovieTicketBookingSystem.Models;
using MovieTicketBookingSystem.Repository.Interfaces;

namespace MovieTicketBookingSystem.Repository.Implementation
{
    public class ScreenRepository : IScreenRepository
    {
        private readonly MovieBookingDbContext _context;

        public ScreenRepository(MovieBookingDbContext context)
        {
            _context = context;
        }

        public Screen Create(Screen screen)
        {
            _context.Screens.Add(screen);
            _context.SaveChanges();
            return screen;
        }

        public List<Screen> GetByTheatre(long theatreId)
        {
            return _context.Screens
                .Include(s => s.ScreenType)
                .Where(s => s.TheatreId == theatreId)
                .ToList();
        }

        public Screen GetById(long screenId)
        {
            return _context.Screens.Find(screenId);
        }

        public void Update(Screen screen)
        {
            _context.Screens.Update(screen);
            _context.SaveChanges();
        }

        public void Delete(long screenId)
        {
            var screen = _context.Screens.Find(screenId);
            if (screen == null)
                throw new Exception("Screen not found");

            _context.Screens.Remove(screen);
            _context.SaveChanges();
        }
    }

}
