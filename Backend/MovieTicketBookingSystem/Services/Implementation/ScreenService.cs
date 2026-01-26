using MovieTicketBookingSystem.DTOs.Screen;
using MovieTicketBookingSystem.Models;
using MovieTicketBookingSystem.Repository.Interfaces;
using MovieTicketBookingSystem.Services.Interfaces;

namespace MovieTicketBookingSystem.Services.Implementation
{
    public class ScreenService : IScreenService
    {
        private readonly IScreenRepository _screenRepository;
        private readonly ITheatreService _theatreService;

        public ScreenService(IScreenRepository screenRepository , ITheatreService theatreService)
        {
            _screenRepository = screenRepository;
            _theatreService = theatreService;
        }

        public Screen CreateScreen(CreateScreenDto dto)
        {
            if (string.IsNullOrEmpty(dto.ScreenName))
                throw new Exception("ScreenName is required");

            if (dto.TheatreId <= 0  || _theatreService.GetById(dto.TheatreId)==null)
                throw new Exception("TheatreId is required");

            var screen = new Screen
            {
                ScreenName = dto.ScreenName,
                TheatreId = dto.TheatreId,
                ScreenTypeId = dto.ScreenTypeId ?? 1,
                TotalSeats = 0 
            };

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
