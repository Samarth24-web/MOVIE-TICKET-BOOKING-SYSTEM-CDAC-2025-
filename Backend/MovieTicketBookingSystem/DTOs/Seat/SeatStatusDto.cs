namespace MovieTicketBookingSystem.DTOs.Seat
{
    public class SeatStatusDto
    {
        public long SeatId { get; set; }
        public string SeatNumber { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public object ShowSeatStatusId { get; internal set; }
    }

}
