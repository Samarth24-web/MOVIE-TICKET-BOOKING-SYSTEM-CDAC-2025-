using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.Services.Interfaces
{
    public interface IScreenService
    {
        Screen CreateScreen(Screen screen);
        List<Screen> GetScreensByTheatre(long theatreId);
        void UpdateScreen(long screenId, string ScreenName);
        void DeleteScreen(long screenId);
    }


}
