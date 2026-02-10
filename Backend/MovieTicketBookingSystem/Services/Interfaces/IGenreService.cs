using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.Services.Interfaces
{
    public interface IGenreService
    {
        List<Genre>? GetAll();
        Genre getGenereById(long genreId);
    }
}
