using Microsoft.AspNetCore.Mvc;
using MovieTicketBookingSystem.Data;
using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        MovieBookingDbContext _dbContext;
        public HomeController(MovieBookingDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        [HttpGet("index")]
        public List<Language> Index()
        {
            return _dbContext.Languages.ToList();
        }
    }
}
