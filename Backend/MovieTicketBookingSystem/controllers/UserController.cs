using Microsoft.AspNetCore.Mvc;
using MovieTicketBookingSystem.Services.Interfaces;

namespace MovieTicketBookingSystem.controllers
{
    [ApiController]
    [Route("/api/users")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet("{userId}")]
        public IActionResult GetProfile(long userId)
        {
            var user = _userService.GetById(userId);
            return Ok(new
            {
                user.UserId,
                user.UserName,
                user.Email,
                user.Phone,
                Role = user.Role.RoleName
            });
        }

    }
}
