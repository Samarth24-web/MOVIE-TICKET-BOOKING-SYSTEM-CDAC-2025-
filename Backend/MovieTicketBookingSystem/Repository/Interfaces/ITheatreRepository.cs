using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.Repository.Interfaces
{
    public interface ITheatreRepository
    {
        void Create(Theatre theatre);
        List<Theatre> GetAll();
        Theatre GetById(long id);
        void Delete(long id);
    }
}
