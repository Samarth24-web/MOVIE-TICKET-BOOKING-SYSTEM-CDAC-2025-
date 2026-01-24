using Microsoft.AspNetCore.Mvc;
using MovieTicketBookingSystem.Models;
using MovieTicketBookingSystem.Services.Interfaces;

namespace MovieTicketBookingSystem.controllers
{
    [Route("api/cities")]
    [ApiController]
    public class CityController : Controller
    {
        public readonly ICityService _cityService;
        public CityController(ICityService cityService) { 
            _cityService = cityService;
        }

        [HttpGet]
        public List<City> getAllCities()
        {
            return _cityService.getAllCities();
        }

        [HttpGet]
        [Route("{id}")]
        public City GetCityById(int id)
        {
            return _cityService.getCityByid(id);
        }
    }
}
