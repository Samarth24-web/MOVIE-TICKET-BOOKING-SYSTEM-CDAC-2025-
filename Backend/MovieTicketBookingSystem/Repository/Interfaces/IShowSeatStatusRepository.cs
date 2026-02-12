using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.Repository.Interfaces
{
    public interface IShowSeatStatusRepository
    {
        void AddRange(List<ShowSeatStatus> statuses);
        List<ShowSeatStatus> GetByShow(long showId);
        List<ShowSeatStatus> GetByIds(List<long> showSeatStatusIds);
        void UpdateRange(List<ShowSeatStatus> seats);
        List<ShowSeatStatus> GetExpiredLockedSeats(DateTime currentTime);
        List<ShowSeatStatus> GetSeatsByBookingId(long bookingId);
        void Update(ShowSeatStatus seatStatus);
    }

}
