using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.Services.Interfaces
{
    public interface ISeatTypeService
    {
        List<SeatType> GetAll();
    }
}
