using MovieTicketBookingSystem.Models;
using MovieTicketBookingSystem.Repository.Interfaces;
using MovieTicketBookingSystem.Services.Interfaces;

namespace MovieTicketBookingSystem.Services.Implementation
{
    public class ScreenService : IScreenService
    {
        private readonly IScreenRepository _screenRepository;

        public ScreenService(IScreenRepository screenRepository)
        {
            _screenRepository = screenRepository;
        }

        public Screen CreateScreen(Screen screen)
        {
            if (string.IsNullOrEmpty(screen.ScreenName))
                throw new Exception("ScreenName is required");

            if (screen.TheatreId <= 0)
                throw new Exception("TheatreId is required");

            screen.ScreenId = 0;              
            screen.TotalSeats = 0;            
            screen.ScreenTypeId = screen.ScreenTypeId == 0 ? 1 : screen.ScreenTypeId;

            return _screenRepository.Create(screen);
        }

        public List<Screen> GetScreensByTheatre(long theatreId)
        {
            return _screenRepository.GetByTheatre(theatreId);
        }

        public void UpdateScreen(long screenId,  String ScreenName)
        {
            var screen = _screenRepository.GetById(screenId);
            if (screen == null)
                throw new Exception("Screen not found");

            if (!string.IsNullOrEmpty(ScreenName))
                screen.ScreenName = ScreenName;

            _screenRepository.Update(screen);
        }

        public void DeleteScreen(long screenId)
        {
            _screenRepository.Delete(screenId);
        }
    }


}
