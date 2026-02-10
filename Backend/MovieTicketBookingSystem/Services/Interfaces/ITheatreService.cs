using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.Services.Interfaces
{
    public interface ITheatreService
    {
        List<Theatre> GetAll();
        Theatre GetById(long id);
        void Delete(long id);
        Theatre GetByManagerId(long id);
    }
}
