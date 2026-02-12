using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.Services.Interfaces
{
    public interface IScreenTypeService
    {
        List<ScreenType>? GetAll();
    }
}
