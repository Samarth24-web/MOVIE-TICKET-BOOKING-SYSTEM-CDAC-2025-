using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.Repository.Interfaces
{
    public interface ISeatRowRepository
    {
        SeatRow GetSeatRowWithSeats(long seatRowId);
        List<SeatRow> GetSeatRowsByScreen(long screenId);
        SeatType GetSeatType(long seatTypeId);

        void AddSeatRow(SeatRow seatRow);
        void AddSeat(Seat seat);
        void RemoveSeat(Seat seat);
        void RemoveSeatRow(SeatRow seatRow);

        void Save();

    }

}
