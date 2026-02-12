using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.Repository.Interfaces
{
    public interface ISeatStatusLogRepository
    {
        void Add(SeatStatusLog log);
        void AddRange(List<SeatStatusLog> logs);
        List<SeatStatusLog> GetByUserId(long userId);
        List<SeatStatusLog> GetByShowId(long showId);
    }
}
