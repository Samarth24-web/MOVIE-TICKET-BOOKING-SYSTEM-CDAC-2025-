using MovieTicketBookingSystem.Data;
using MovieTicketBookingSystem.Models;
using MovieTicketBookingSystem.Repository.Interfaces;

namespace MovieTicketBookingSystem.Repository.Implementation
{
    public class CityRepository : ICityRepository
    {
        private readonly MovieBookingDbContext _context;

        public CityRepository(MovieBookingDbContext context)
        {
            _context = context;
        }

        public List<City> findAll()
        {
            List<City> cities = (from c in _context.Cities
                                 orderby c.StateName , c.CityName
                                 select c).ToList();
            return cities;
        }

        public City findById(int id)
        {
            City? city = _context.Cities.FirstOrDefault(c => c.CityId == id);
            return city;
        }
    }
}
