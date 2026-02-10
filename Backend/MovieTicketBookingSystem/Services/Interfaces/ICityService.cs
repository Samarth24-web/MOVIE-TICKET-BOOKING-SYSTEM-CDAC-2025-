using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.Services.Interfaces
{
    public interface ICityService
    {
         List<City> getAllCities();
        City getCityByid(int id);
    }
}
