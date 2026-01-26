using MovieTicketBookingSystem.DTOs.Seat;
using MovieTicketBookingSystem.Repository.Interfaces;
using MovieTicketBookingSystem.Services.Interfaces;

namespace MovieTicketBookingSystem.Services.Implementation
{
    public class SeatHistoryService : ISeatHistoryService
    {
        private readonly ISeatStatusLogRepository _repo;

        public SeatHistoryService(ISeatStatusLogRepository repo)
        {
            _repo = repo;
        }

        public List<SeatStatusHistoryDto> GetByUser(long userId)
        {
            return _repo.GetByUserId(userId)
                .Select(x => new SeatStatusHistoryDto
                {
                    SeatId = x.SeatId,
                    OldStatus = x.OldStatus,
                    NewStatus = x.NewStatus,
                    ChangedAt = x.ChangedAt,
                    BookingId = x.BookingId
                }).ToList();
        }

        public List<SeatStatusHistoryDto> GetByShow(long showId)
        {
            return _repo.GetByShowId(showId)
                .Select(x => new SeatStatusHistoryDto
                {
                    SeatId = x.SeatId,
                    OldStatus = x.OldStatus,
                    NewStatus = x.NewStatus,
                    ChangedAt = x.ChangedAt,
                    BookingId = x.BookingId
                }).ToList();
        }
    }
}
