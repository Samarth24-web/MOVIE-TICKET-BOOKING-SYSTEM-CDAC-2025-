using Microsoft.EntityFrameworkCore;
using MovieTicketBookingSystem.Data;
using MovieTicketBookingSystem.Models;
using MovieTicketBookingSystem.Repository.Interfaces;

namespace MovieTicketBookingSystem.Repository.Implementation
{
    public class TheatreRepository : ITheatreRepository
    {
        private readonly MovieBookingDbContext _context;

        public TheatreRepository(MovieBookingDbContext context)
        {
            _context = context;
        }

        public void Create(Theatre theatre)
        {
            _context.Theatres.Add(theatre);
            _context.SaveChanges();
        }

        public List<Theatre> GetAll()
        {
            return _context.Theatres
                .Include(t => t.City)
                .ToList();
        }

        public Theatre GetById(long id)
        {
            return _context.Theatres
                .Include(t => t.City)
                .FirstOrDefault(t => t.TheatreId == id);
        }

        public void Delete(long id)
        {
            var theatre = _context.Theatres.Find(id);
            if (theatre == null) throw new Exception("Theatre not found");

            _context.Users.FirstOrDefault(u => u.UserId == theatre.ManagerId).RoleId = 1;

            _context.Theatres.Remove(theatre);
            _context.SaveChanges();
        }
    }
}
