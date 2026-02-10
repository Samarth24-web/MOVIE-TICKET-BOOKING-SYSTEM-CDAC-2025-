using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.Utilities
{
    public static class PriceCalculator
    {
        public static decimal CalculateTotalPrice(
            IEnumerable<ShowSeatStatus> seats)
        {
            return seats.Sum(s => s.Seat?.Price??0);
        }

        public static decimal CalculateSeatPrice(
            ShowSeatStatus seatStatus)
        {
            return seatStatus.Seat.Price;
        }
    }
}
