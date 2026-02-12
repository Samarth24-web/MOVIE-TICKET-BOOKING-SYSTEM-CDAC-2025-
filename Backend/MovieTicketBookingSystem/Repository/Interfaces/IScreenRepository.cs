using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.Repository.Interfaces
{
    public interface IScreenRepository
    {
        Screen Create(Screen screen);
        List<Screen> GetByTheatre(long theatreId);
        Screen GetById(long screenId);
        void Update(Screen screen);
        void Delete(long screenId);
        List<Screen>? GetByManager(long managerId);
    }
}
