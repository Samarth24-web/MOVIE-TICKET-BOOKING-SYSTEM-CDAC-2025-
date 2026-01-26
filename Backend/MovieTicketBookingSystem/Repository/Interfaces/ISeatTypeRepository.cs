using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.Repository.Interfaces
{
    public interface ISeatTypeRepository
    {
        List<SeatType> GetAll();
    }
}
