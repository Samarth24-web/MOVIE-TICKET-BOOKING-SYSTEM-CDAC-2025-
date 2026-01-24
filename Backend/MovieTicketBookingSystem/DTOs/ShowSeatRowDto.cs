namespace MovieTicketBookingSystem.DTOs
{
    public class ShowSeatRowDto
    {
        public long SeatRowId { get; set; }
        public string RowName { get; set; }
        public int RowOrder { get; set; }
        public List<SeatStatusDto> Seats { get; set; }
    }

}
