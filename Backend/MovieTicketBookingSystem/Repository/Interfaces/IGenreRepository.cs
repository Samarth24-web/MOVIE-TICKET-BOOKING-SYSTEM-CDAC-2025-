using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.Repository.Interfaces
{
    public interface IGenreRepository
    {
        Genre findById(long genreId);
    }
}
