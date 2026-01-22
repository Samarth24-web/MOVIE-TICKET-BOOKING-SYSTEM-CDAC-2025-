using Microsoft.EntityFrameworkCore;
using MovieTicketBookingSystem.Data;
using MovieTicketBookingSystem.DTOs;
using MovieTicketBookingSystem.Models;
using MovieTicketBookingSystem.Services.Implementation;
using MovieTicketBookingSystem.Services.Interfaces;

namespace MovieTicketBookingSystem.Services.Implementation
{

    public class AuthService : IAuthService
    {
        private readonly IUserService _UserService;
        private readonly IJwtService _jwt;

        public AuthService(IUserService userService, IJwtService jwt)
        {
            _UserService = userService;
            _jwt = jwt;
        }

        public async Task<AuthResponseDto> Register(RegisterDto dto )
        {
            if (await _UserService.IsEmailUnique(dto.Email))
                throw new Exception("EMAIL ALREADY EXISTS!");
            if (await _UserService.IsPhoneUnique(dto.Phone))
                throw new Exception("PHONE NUMBER ALREADY EXISTS!");

            var user = new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                Phone = dto.Phone,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                RoleId = 1
            };

            await _UserService.AddUser(user);

            var token = _jwt.GenerateToken(user, "User");

            return new AuthResponseDto
            {
                Token = token,
                UserId = user.UserId,
                Role = "User"
            };
        }

        public async Task<AuthResponseDto> Login(LoginDto dto)
        {
            var user = await _UserService.GetUserByEmail(dto.Email);

            if (user == null ||
                !BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
                throw new Exception("Invalid credentials");

            var token = _jwt.GenerateToken(user, user.Role.RoleName);
           

            return new AuthResponseDto
            {
                Token = token,
                UserId = user.UserId,
                Role = user.Role.RoleName
            };
        }

    }
}


