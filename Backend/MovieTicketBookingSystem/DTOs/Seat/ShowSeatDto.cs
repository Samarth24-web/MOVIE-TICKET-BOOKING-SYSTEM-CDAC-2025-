namespace MovieTicketBookingSystem.DTOs.Seat
{
    public class ShowSeatDto
    {
        public long ShowSeatStatusId { get; set; }
        public long SeatId { get; set; }
        public string SeatNumber { get; set; }
        public string Status { get; set; }
        public decimal Price { get; set; }
    }
}
