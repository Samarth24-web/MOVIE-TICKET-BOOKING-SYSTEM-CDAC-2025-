using Microsoft.EntityFrameworkCore;
using MovieTicketBookingSystem.Data;
using MovieTicketBookingSystem.Models;
using MovieTicketBookingSystem.Repository.Interfaces;

namespace MovieTicketBookingSystem.Repository.Implementation
{
    public class SeatRowRepository : ISeatRowRepository
    {
        private readonly MovieBookingDbContext _context;

        public SeatRowRepository(MovieBookingDbContext context)
        {
            _context = context;
        }

        public SeatRow GetSeatRowWithSeats(long seatRowId)
        {
            return _context.SeatRows
                .Include(r => r.Seats)
                .FirstOrDefault(r => r.SeatRowId == seatRowId);
        }

        public List<SeatRow> GetSeatRowsByScreen(long screenId)
        {
            return _context.SeatRows
                .Include(r => r.Seats)
                .Where(r => r.ScreenId == screenId)
                .OrderBy(r => r.RowName)
                .Select(r => new SeatRow
                {
                    SeatRowId = r.SeatRowId,
                    RowName = r.RowName,
                    ScreenId = r.ScreenId,
                    Seats = r.Seats
                        .OrderBy(s => s.SeatNumber)
                        .ToList()
                })
                .ToList();
        }

        public SeatType GetSeatType(long seatTypeId)
        {
            return _context.SeatTypes
                .FirstOrDefault(s => s.SeatTypeId == seatTypeId);
        }

        public void AddSeatRow(SeatRow seatRow)
        {
            _context.SeatRows.Add(seatRow);
        }

        public void AddSeat(Seat seat)
        {
            _context.Seats.Add(seat);
        }

        public void RemoveSeat(Seat seat)
        {
            _context.Seats.Remove(seat);
        }

        public void RemoveSeatRow(SeatRow seatRow)
        {
            _context.SeatRows.Remove(seatRow);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }

}
