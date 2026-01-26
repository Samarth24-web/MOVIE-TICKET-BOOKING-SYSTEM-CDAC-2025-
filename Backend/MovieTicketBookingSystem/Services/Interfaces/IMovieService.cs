using MovieTicketBookingSystem.DTOs.Movie;

namespace MovieTicketBookingSystem.Services.Interfaces
{
    public interface IMovieService
    {
       Task<long> CreateMovieAsync(CreateMovieDto dto);
        List<string> findBySearchStartLetters(string startsWith);
        List<MovieResponseDto> findLatestTrendingMoviesSortByDateAndRating(int count);
        List<MovieResponseDto> getAllMovies();
        MovieResponseDto getMovieBtName(string name);
        MovieResponseDto getMovieByid(int movieId);
    }
}
