using MovieTicketBookingSystem.DTOs;
using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.Repository.Interfaces
{
    public interface IMovieRepository
    {
        List<Movie> findAll();
        Movie findByID(int movieId);
        Movie findByName(string name);
        List<Movie> findBySearchStartLetters(string startsWith);
        List<Movie> findLatestTrendingMoviesSortByDateAndRating(int count);
    }
}
