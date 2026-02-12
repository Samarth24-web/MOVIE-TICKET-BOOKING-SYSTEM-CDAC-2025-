namespace MovieTicketBookingSystem.DTOs.Seat
{
    public class SeatStatusHistoryDto
    {
        public long SeatId { get; set; }
        public string OldStatus { get; set; }
        public string NewStatus { get; set; }
        public DateTime ChangedAt { get; set; }
        public long? BookingId { get; set; }
    }
}
