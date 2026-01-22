using Microsoft.IdentityModel.Tokens;
using MovieTicketBookingSystem.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MovieTicketBookingSystem.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user, string role);
    }

    

}
