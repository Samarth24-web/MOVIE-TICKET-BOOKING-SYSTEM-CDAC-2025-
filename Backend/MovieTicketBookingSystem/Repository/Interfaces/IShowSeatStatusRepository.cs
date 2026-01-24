using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.Repository.Interfaces
{
    public interface IShowSeatStatusRepository
    {
        void AddRange(List<ShowSeatStatus> statuses);
        List<ShowSeatStatus> GetByShow(long showId);
    }

}
