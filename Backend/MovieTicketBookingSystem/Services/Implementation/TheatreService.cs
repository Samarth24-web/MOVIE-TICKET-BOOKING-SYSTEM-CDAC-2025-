using MovieTicketBookingSystem.Models;
using MovieTicketBookingSystem.Repository.Interfaces;
using MovieTicketBookingSystem.Services.Interfaces;

namespace MovieTicketBookingSystem.Services.Implementation
{
    public class TheatreService : ITheatreService
    {
        private readonly ITheatreRepository _theatreRepository;

        public TheatreService(ITheatreRepository theatreRepository)
        {
            _theatreRepository = theatreRepository;
        }

        public List<Theatre> GetAll()
        {
            return _theatreRepository.GetAll();
        }

        public Theatre GetById(long id)
        {
            return _theatreRepository.GetById(id);
        }

        public void Delete(long id)
        {
            _theatreRepository.Delete(id);
        }

        public Theatre GetByManagerId(long id)
        {
            return _theatreRepository.GetByManagerId(id);
        }
    }
}
