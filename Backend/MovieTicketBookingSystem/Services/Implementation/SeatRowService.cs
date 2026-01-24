using MovieTicketBookingSystem.DTOs;
using MovieTicketBookingSystem.Models;
using MovieTicketBookingSystem.Repository.Interfaces;
using MovieTicketBookingSystem.Services.Interfaces;
using MovieTicketBookingSystem.Utils;

namespace MovieTicketBookingSystem.Services.Implementation
{
    public class SeatRowService : ISeatRowService
    {
        private readonly ISeatRowRepository _repo;

        public SeatRowService(ISeatRowRepository repo)
        {
            _repo = repo;
        }

        public SeatRowDto CreateSeatRow(CreateSeatRowDto dto)
        {
            var defaultSeatType = _repo.GetSeatType(1);

            var seatRow = new SeatRow
            {
                ScreenId = dto.ScreenId,
                RowName = dto.RowName,
                Seats = new List<Seat>()
            };

            for (int i = 1; i <= dto.NumberOfSeats; i++)
            {
                seatRow.Seats.Add(new Seat
                {
                    SeatNumber = i.ToString(),
                    SeatTypeId = defaultSeatType.SeatTypeId,
                    Price = defaultSeatType.BasePrice
                });
            }

            _repo.AddSeatRow(seatRow);
            _repo.Save();

            return SeatRowMapper.SeatRowToSeatRowDto(seatRow);
        }

        public SeatRowDto UpdateSeatRowName(long seatRowId, string newName)
        {
            var row = _repo.GetSeatRowWithSeats(seatRowId);
            row.RowName = newName;

            _repo.Save();
            return SeatRowMapper.SeatRowToSeatRowDto(row);
        }

        public SeatRowDto AddSeat(long seatRowId, SeatDto dto)
        {
            var row = _repo.GetSeatRowWithSeats(seatRowId);

            if (row.Seats.Any(s => s.SeatNumber == dto.SeatNumber))
                throw new Exception("Seat number already exists in this row");

            var seat = SeatMapper.SeatDtoToSeat(dto);
            seat.SeatRowId = seatRowId;

            _repo.AddSeat(seat);
            _repo.Save();

            return SeatRowMapper.SeatRowToSeatRowDto(row);
        }

        public SeatRowDto UpdateSeat(long seatRowId, long seatId, SeatDto dto)
        {
            var row = _repo.GetSeatRowWithSeats(seatRowId);
            var seat = row.Seats.First(s => s.SeatId == seatId);

            if (row.Seats.Any(s => s.SeatId != seatId && s.SeatNumber == dto.SeatNumber))
                throw new Exception("Duplicate seat number in row");

            seat.SeatNumber = dto.SeatNumber;
            seat.SeatTypeId = dto.SeatTypeId;
            seat.Price = dto.Price;

            _repo.Save();
            return SeatRowMapper.SeatRowToSeatRowDto(row);
        }

        public void DeleteSeat(long seatRowId, long seatId)
        {
            var row = _repo.GetSeatRowWithSeats(seatRowId);
            var seat = row.Seats.First(s => s.SeatId == seatId);

            _repo.RemoveSeat(seat);

            if (row.Seats.Count == 1)
                _repo.RemoveSeatRow(row);

            _repo.Save();
        }

        public List<SeatRowDto> GetSeatRowsByScreen(long screenId)
        {
            var rows = _repo.GetSeatRowsByScreen(screenId);
            return rows.Select(SeatRowMapper.SeatRowToSeatRowDto).ToList();
        }
    }

}
