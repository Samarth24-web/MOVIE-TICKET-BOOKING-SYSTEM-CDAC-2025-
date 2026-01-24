using MovieTicketBookingSystem.DTOs;
using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.Utils
{
    public class Mapper
    {
        static Mapper()
        { 
        }
        public Mapper() { 
        }


        public static MovieResponseDto MovieToMovieResponseDto(Movie movie)
        {
            if (movie == null) return null;

            return new MovieResponseDto
            {
                MovieId = movie.MovieId,
                Title = movie.Title,
                Duration = movie.Duration,
                Rating = movie.Rating,
                Description = movie.Description,
                ReleaseDate = movie.ReleaseDate,
                ImageUrl = movie.ImageUrl,

                Genres = movie.Genres
                    .Select(g => g.GenreId.ToString())
                    .ToList(),

                Languages = movie.Languages
                    .Select(l => l.LanguageId.ToString())
                    .ToList()
            };
        }


    }
}
