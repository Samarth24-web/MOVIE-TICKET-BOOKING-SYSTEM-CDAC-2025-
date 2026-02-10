using MovieTicketBookingSystem.Models;
using MovieTicketBookingSystem.Repository.Interfaces;
using MovieTicketBookingSystem.Services.Interfaces;

namespace MovieTicketBookingSystem.Services.Implementation
{
    public class ScreenTypeService : IScreenTypeService
    {

        private readonly IScreenTypeRepository _screenTypeRepository;

        public ScreenTypeService(IScreenTypeRepository screenTypeRepository)
        {
            _screenTypeRepository = screenTypeRepository;
        }
        public List<ScreenType> GetAll()
        {
            return _screenTypeRepository.GetAll();
        }
    }
}
