using MovieTicketBookingSystem.Models;
using MovieTicketBookingSystem.Repository.Interfaces;
using MovieTicketBookingSystem.Services.Interfaces;

namespace MovieTicketBookingSystem.Services.Implementation
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genereRepository;
        public GenreService(IGenreRepository genereRepository)
        {
            _genereRepository = genereRepository;
        }

        internal object getGenereById(long genreId)
        {
            throw new NotImplementedException();
        }

        Genre IGenreService.getGenereById(long genreId)
        {
            return _genereRepository.findById(genreId);
        }
    }
}
