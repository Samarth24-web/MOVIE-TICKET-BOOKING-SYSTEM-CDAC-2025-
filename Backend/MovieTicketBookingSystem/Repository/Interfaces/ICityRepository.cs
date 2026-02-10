using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.Repository.Interfaces
{
    public interface ICityRepository
    {
        List<City> findAll();
        City findById(int id);
    }
}
