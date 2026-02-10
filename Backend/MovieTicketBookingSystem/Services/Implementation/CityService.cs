using MovieTicketBookingSystem.Models;
using MovieTicketBookingSystem.Repository.Interfaces;
using MovieTicketBookingSystem.Services.Interfaces;

namespace MovieTicketBookingSystem.Services.Implementation
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        public CityService(ICityRepository cityRepository) {
            _cityRepository = cityRepository;
        }
        public List<City> getAllCities()
        {
            return _cityRepository.findAll();
        }

        public City getCityByid(int id)
        {
            return _cityRepository.findById(id);
        }
    }
}
