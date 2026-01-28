using Microsoft.EntityFrameworkCore;
using MovieTicketBookingSystem.Data;
using MovieTicketBookingSystem.DTOs.Movie;
using MovieTicketBookingSystem.Models;
using MovieTicketBookingSystem.Repository.Interfaces;
using MovieTicketBookingSystem.Services.Interfaces;
using MovieTicketBookingSystem.Utils;

namespace MovieTicketBookingSystem.Services.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IFileStorageService _fileStorageService;
        private readonly MovieBookingDbContext _context;
        public MovieService(IMovieRepository movieRepository, IFileStorageService fileStorageService , MovieBookingDbContext context)
        {
            _movieRepository = movieRepository;
            _fileStorageService = fileStorageService;
            _context = context;
        }

        public void convertMapping(MovieResponseDto dto)
        {
            if (dto == null) return ;
            dto.Genres = (from g in dto.Genres
                          select _context.Genres.FirstOrDefault(s => s.GenreId == Convert.ToInt64(g)).GenreName
                         ).ToList();
            dto.Languages = (from l in dto.Languages
                          select _context.Languages.FirstOrDefault(s => s.LanguageId== Convert.ToInt64(l)).LanguageName
                         ).ToList();
        }
        public async Task<long> CreateMovieAsync(CreateMovieDto dto)
        {
            try
            {
                var imageUrl = await _fileStorageService
                    .UploadFileAsync(dto.Image, "movies");

                var movie = new Movie
                {
                    Title = dto.Title,
                    Duration = dto.Duration,
                    Rating = dto.Rating,
                    Description = dto.Description,
                    ReleaseDate = dto.ReleaseDate,
                    ImageUrl = imageUrl
                };

                _context.Movies.Add(movie);
                await _context.SaveChangesAsync(); // MovieId generated

                if (dto.GenreIds?.Any() == true)
                {
                    var genreMappings = dto.GenreIds.Select(id =>
                        new MovieGenreMap
                        {
                            MovieId = movie.MovieId,
                            GenreId = id
                        });

                    _context.MovieGenreMaps.AddRange(genreMappings);
                }

                if (dto.LanguageIds?.Any() == true)
                {
                    var languageMappings = dto.LanguageIds.Select(id =>
                        new MovieLanguageMap
                        {
                            MovieId = movie.MovieId,
                            LanguageId = id
                        });

                    _context.MovieLanguageMaps.AddRange(languageMappings);
                }

                await _context.SaveChangesAsync();

                return movie.MovieId;
            }
            catch
            {
                throw; // let controller handle error
            }
        }


        public List<string> findBySearchStartLetters(string startsWith)
        {
            List<Movie> movies = _movieRepository.findBySearchStartLetters(startsWith);
            List<String> names = (from m in movies
                                  select m.Title
                                  ).ToList();
            return names;
        }

        public List<MovieResponseDto> findLatestTrendingMoviesSortByDateAndRating(int count)
        {
            List<Movie> movies = _movieRepository.findLatestTrendingMoviesSortByDateAndRating(count);
            List<MovieResponseDto> movieResponseDtos = movies
                                                            .Select(m =>
                                                            {
                                                                var dto = MovieMapper.MovieToMovieResponseDto(m);
                                                                convertMapping(dto); 
                                                                return dto;
                                                            })
                                                            .ToList();
            return movieResponseDtos;
        }

        public List<MovieResponseDto> getAllMovies()
        {
            List<Movie> movies = _movieRepository.findAll();
            List<MovieResponseDto> responseDtos = new List<MovieResponseDto>();
            foreach(Movie m in movies)
            {
                MovieResponseDto dto = MovieMapper.MovieToMovieResponseDto(m);
                convertMapping(dto);
                responseDtos.Add(dto);
            }
            return responseDtos;
        }

        public MovieResponseDto getMovieBtName(string name)
        {
            MovieResponseDto m = MovieMapper.MovieToMovieResponseDto(_movieRepository.findByName(name));
            convertMapping(m);
            return m;
        }

        public MovieResponseDto getMovieByid(int movieId)
        {
            MovieResponseDto m = MovieMapper.MovieToMovieResponseDto(_movieRepository.findByID(movieId));
            convertMapping(m);
            return m;
        }
    }
}
