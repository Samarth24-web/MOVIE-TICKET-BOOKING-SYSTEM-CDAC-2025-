namespace MovieTicketBookingSystem.DTOs.Seat
{
    public class SeatRowLayoutDto
    {
        public long SeatRowId { get; set; }
        public string RowName { get; set; }
        public int RowOrder { get; set; }
        public List<ShowSeatDto> Seats { get; set; }
    }
}
