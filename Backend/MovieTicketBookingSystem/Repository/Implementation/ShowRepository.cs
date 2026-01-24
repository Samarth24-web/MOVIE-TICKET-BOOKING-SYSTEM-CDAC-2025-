using Microsoft.EntityFrameworkCore;
using MovieTicketBookingSystem.Data;
using MovieTicketBookingSystem.Models;
using MovieTicketBookingSystem.Repository.Interfaces;

namespace MovieTicketBookingSystem.Repository.Implementation
{
    public class ShowRepository : IShowRepository
    {
        private readonly MovieBookingDbContext _context;

        public ShowRepository(MovieBookingDbContext context)
        {
            _context = context;
        }

        public Show Add(Show show)
        {
            _context.Shows.Add(show);
            _context.SaveChanges();
            return show;
        }

        public Show GetById(long showId)
        {
            return _context.Shows
                .Include(s => s.Movie)
                .Include(s => s.Screen)
                    .ThenInclude(sc => sc.Theatre)
                .FirstOrDefault(s => s.ShowId == showId);
        }

        public List<Show> GetPastShows(long managerId)
        {
            return _context.Shows
                .Where(s =>
                    s.CreatedByManagerId == managerId &&
                    s.ShowDate < DateTime.Today)
                .OrderByDescending(s => s.ShowDate)
                .ToList();
        }

        public List<Show> GetUpcomingShows(long managerId)
        {
            return _context.Shows
                .Where(s =>
                    s.CreatedByManagerId == managerId &&
                    s.ShowDate >= DateTime.Today)
                .OrderBy(s => s.ShowDate)
                .ToList();
        }
    }

}
