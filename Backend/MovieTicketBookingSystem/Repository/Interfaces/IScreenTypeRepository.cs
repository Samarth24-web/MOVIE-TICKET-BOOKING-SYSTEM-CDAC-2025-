using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.Repository.Interfaces
{
    public interface IScreenTypeRepository
    {
        List<ScreenType> GetAll();
    }
}
