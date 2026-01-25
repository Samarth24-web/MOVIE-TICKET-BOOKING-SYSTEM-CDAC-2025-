using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.Repository.Interfaces
{
    public interface IShowRepository
    {
        Show Add(Show show);
        Show GetById(long showId);
        List<Show> GetPastShows(long managerId);
        List<Show> GetUpcomingShows(long managerId);
        List<Show> GetShowsByCityMovieDate(
               string cityName,
               long movieId,
               DateTime showDate
           );
    }

}
