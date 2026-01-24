using MovieTicketBookingSystem.DTOs;
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
    }

}
