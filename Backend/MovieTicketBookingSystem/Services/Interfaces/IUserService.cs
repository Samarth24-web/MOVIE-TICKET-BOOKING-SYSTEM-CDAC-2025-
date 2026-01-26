using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> IsEmailUnique(string email);
        Task<bool> IsPhoneUnique(string phone);
        Task<User> AddUser(User user);
        Task<User> GetUserByEmail(string email);
        User GetById(long userId);
    }
}
