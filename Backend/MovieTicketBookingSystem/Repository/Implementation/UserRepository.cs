using Microsoft.EntityFrameworkCore;
using MovieTicketBookingSystem.Data;
using MovieTicketBookingSystem.Models;
using MovieTicketBookingSystem.Repository.Interfaces;

namespace MovieTicketBookingSystem.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly MovieBookingDbContext _context;
        public UserRepository(MovieBookingDbContext context) {
            _context = context;
        }

        public Task<bool> hasUniqueEmail(string email)
        {
            bool check =!_context.Users.Any(u => u.Email == email);
            return Task.FromResult(check);
        }

        public Task<bool> hasUniquePhone(string phone)
        {
            bool check = !_context.Users.Any(u => u.Phone == phone);
            return Task.FromResult(check);
        }

        public async Task<Models.User> AddUser(Models.User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<Models.User> findByEmail(string email)
        {
            User? user = _context.Users.Include(u => u.Role).FirstOrDefault(u => u.Email == email);
            return await Task.FromResult(user);
        }
    }
}
