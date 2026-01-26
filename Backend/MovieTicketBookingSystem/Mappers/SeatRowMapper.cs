using MovieTicketBookingSystem.DTOs.Seat;
using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.Utils
{
    public static class SeatRowMapper
    {
        public static SeatRowDto SeatRowToSeatRowDto(SeatRow row)
        {
            return new SeatRowDto
            {
                RowName = row.RowName,
                TotalSeats = row.Seats.Count,
                Seats = row.Seats
                    .OrderBy(s => s.SeatNumber)
                    .Select(SeatMapper.SeatToSeatDto)
                    .ToList()
            };
        }
    }

}
