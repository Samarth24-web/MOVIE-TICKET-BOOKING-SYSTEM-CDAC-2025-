using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.Repository.Interfaces
{
    public interface ISeatRepository
    {
        List<Seat> GetSeatsByScreen(long screenId);
    }

}
