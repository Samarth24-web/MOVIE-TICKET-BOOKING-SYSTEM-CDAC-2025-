using MovieTicketBookingSystem.DTOs.Screen;
using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.Services.Interfaces
{
    public interface IScreenService
    {
        Screen CreateScreen(CreateScreenDto dto);
        List<Screen> GetScreensByTheatre(long theatreId);
        void UpdateScreen(long screenId, string ScreenName);
        void DeleteScreen(long screenId);
        List<Screen>? GetByManager(long managerId);
    }


}
