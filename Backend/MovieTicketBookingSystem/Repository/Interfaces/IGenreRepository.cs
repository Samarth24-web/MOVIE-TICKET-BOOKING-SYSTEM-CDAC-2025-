using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.Repository.Interfaces
{
    public interface IGenreRepository
    {
        List<Genre> FindAll();
        Genre findById(long genreId);
    }
}
