using Microsoft.IdentityModel.Tokens;
using MovieTicketBookingSystem.DTOs.Auth;
using MovieTicketBookingSystem.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MovieTicketBookingSystem.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto> Register(RegisterDto dto);
        Task<AuthResponseDto> Login(LoginDto dto);
    }
    
}

