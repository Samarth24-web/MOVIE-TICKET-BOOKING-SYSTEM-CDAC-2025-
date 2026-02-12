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

        public List<Genre> GetAll()
        {
            return _genereRepository.FindAll();
        }

        Genre IGenreService.getGenereById(long genreId)
        {
            return _genereRepository.findById(genreId);
        }
    }
}
