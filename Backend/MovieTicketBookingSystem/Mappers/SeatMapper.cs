using MovieTicketBookingSystem.DTOs.Seat;
using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.Utils
{
    public static class SeatMapper
    {
        public static SeatDto SeatToSeatDto(Seat seat)
        {
            return new SeatDto
            {
                SeatNumber = seat.SeatNumber,
                SeatTypeId = seat.SeatTypeId,
                Price = seat.Price
            };
        }

        public static Seat SeatDtoToSeat(SeatDto dto)
        {
            return new Seat
            {
                SeatNumber = dto.SeatNumber,
                SeatTypeId = dto.SeatTypeId,
                Price = dto.Price
            };
        }

        public static ShowSeatDto ShowSeatStatusToShowSeatDto(ShowSeatStatus status)
        {
            return new ShowSeatDto
            {
                ShowSeatStatusId = status.ShowSeatStatusId,
                SeatId = status.SeatId,
                SeatNumber = status.Seat.SeatNumber,
                Status = status.Status,
                Price = status.Seat.Price
            };
        }

        public static SeatRowLayoutDto SeatRowToSeatRowLayoutDto(
            SeatRow row,
            List<ShowSeatStatus> seatStatuses)
        {
            return new SeatRowLayoutDto
            {
                SeatRowId = row.SeatRowId,
                RowName = row.RowName,
                RowOrder = row.RowOrder,
                Seats = seatStatuses
                    .Where(s => s.Seat.SeatRowId == row.SeatRowId)
                    .Select(ShowSeatStatusToShowSeatDto)
                    .OrderBy(s => s.SeatNumber)
                    .ToList()
            };
        }

    }

}
