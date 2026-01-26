using MovieTicketBookingSystem.DTOs.Seat;

namespace MovieTicketBookingSystem.Services.Interfaces
{
    public interface ISeatHistoryService
    {
        List<SeatStatusHistoryDto> GetByUser(long userId);
        List<SeatStatusHistoryDto> GetByShow(long showId);
    }
}
