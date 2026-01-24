using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.Services.Interfaces
{
    public interface IGenreService
    {
        Genre getGenereById(long genreId);
    }
}
