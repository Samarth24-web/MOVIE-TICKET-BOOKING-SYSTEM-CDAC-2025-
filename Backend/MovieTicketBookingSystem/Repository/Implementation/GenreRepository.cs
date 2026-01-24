using MovieTicketBookingSystem.Data;
using MovieTicketBookingSystem.Models;
using MovieTicketBookingSystem.Repository.Interfaces;

namespace MovieTicketBookingSystem.Repository.Implementation
{
    public class GenreRepository : IGenreRepository
    {
        private readonly MovieBookingDbContext _context;

        public GenreRepository(MovieBookingDbContext context)
        {
            _context = context;
        }

        public Genre findById(long genreId)
        {
            return _context.Genres.FirstOrDefault(g=>g.GenreId==genreId);
        }
    }
}
