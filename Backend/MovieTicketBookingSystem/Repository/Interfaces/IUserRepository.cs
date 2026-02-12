using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> hasUniqueEmail(string email);
        Task<bool> hasUniquePhone(string phone);
        Task<User> AddUser(User user);
        Task<User> findByEmail(string email);
        User GetById(long userId);
    }
}
