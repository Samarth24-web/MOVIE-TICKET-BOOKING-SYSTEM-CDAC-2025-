using MovieTicketBookingSystem.Models;
using MovieTicketBookingSystem.Repository.Interfaces;
using MovieTicketBookingSystem.Services.Interfaces;

namespace MovieTicketBookingSystem.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepository;
        public UserService(IUserRepository userRepository) {
            _UserRepository = userRepository;
        }
        public Task<bool> IsEmailUnique(string email)
        {
            return _UserRepository.hasUniqueEmail(email);
        }
        public Task<bool> IsPhoneUnique(string phone)
        {
            return _UserRepository.hasUniquePhone(phone);
        }

        public Task<User> AddUser(User user) 
        { 
            return _UserRepository.AddUser(user);
        }

        public Task<User> GetUserByEmail(string email)
        {
            return _UserRepository.findByEmail(email);
        }

        public User GetById(long userId)
        {
            return _UserRepository.GetById(userId);
        }
    }
}
