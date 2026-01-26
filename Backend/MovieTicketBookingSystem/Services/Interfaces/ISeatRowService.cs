using MovieTicketBookingSystem.DTOs.Seat;

namespace MovieTicketBookingSystem.Services.Interfaces
{
    public interface ISeatRowService
    {
        SeatRowDto CreateSeatRow(CreateSeatRowDto dto);
        SeatRowDto UpdateSeatRowName(long seatRowId, string newName);

        SeatRowDto AddSeat(long seatRowId, SeatDto dto);
        SeatRowDto UpdateSeat(long seatRowId, long seatId, SeatDto dto);

        void DeleteSeat(long seatRowId, long seatId);

        List<SeatRowDto> GetSeatRowsByScreen(long screenId);
    }

}
