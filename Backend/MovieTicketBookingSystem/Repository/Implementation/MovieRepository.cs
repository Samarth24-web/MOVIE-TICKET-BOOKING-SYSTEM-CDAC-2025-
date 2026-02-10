using Microsoft.EntityFrameworkCore;
using MovieTicketBookingSystem.Data;
using MovieTicketBookingSystem.Models;
using MovieTicketBookingSystem.Repository.Interfaces;

namespace MovieTicketBookingSystem.Repository.Implementation
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieBookingDbContext _context;

        public MovieRepository(MovieBookingDbContext context)
        {
            _context = context;
        }

        public List<Movie> findAll()
        {
            return _context.Movies.Include(m=>m.Genres).Include(m=>m.Languages).ToList();
        }

        public Movie findByID(int movieId) 
        {
            return _context.Movies.Include(m => m.Genres).Include(m => m.Languages).FirstOrDefault(m => m.MovieId == movieId);
        }

        public Movie findByName(string name)
        {
            return _context.Movies.Include(m => m.Genres).Include(m => m.Languages).FirstOrDefault(m => m.Title == name);
        }

        public List<Movie> findBySearchStartLetters(string startsWith)
        {
            List<Movie> movies = (from m in _context.Movies.Include(m => m.Genres).Include(m => m.Languages)
                                  where m.Title.StartsWith(startsWith)
                                  orderby m.Title
                                  select m
                                 ).Take(10).ToList();
            return movies;
        }

        public List<Movie> findLatestTrendingMoviesSortByDateAndRating(int count)
        {
            List<Movie> movies = (from m in _context.Movies.Include(m => m.Genres).Include(m => m.Languages)
                                  orderby m.ReleaseDate descending , m.Rating descending
                                  select m
                                  ).Take(count).ToList();
            return movies;
        }
    }
}
