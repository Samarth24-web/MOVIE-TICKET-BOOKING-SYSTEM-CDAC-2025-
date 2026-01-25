using MovieTicketBookingSystem.DTOs;

namespace MovieTicketBookingSystem.Services.Interfaces
{
    public interface IShowService
    {
        ShowDto RegisterShow(CreateShowDto dto);
        ShowSeatLayoutDto GetSeatLayout(long showId);
        List<ShowDto> GetPastShows(long managerId);
        List<ShowDto> GetUpcomingShows(long managerId);
        ShowDto GetById(long id);

        List<ScreenMovieShowsDto> GetShowsByCityMovieDate(
                string city,
                long movieId,
                DateTime date
            );

    }

}
