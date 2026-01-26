namespace MovieTicketBookingSystem.DTOs.Show
{
    public class ShowSeatLayoutDto
    {
        public long ShowId { get; set; }
        public string MovieName { get; set; }
        public DateTime ShowDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public List<ShowSeatRowDto> SeatRows { get; set; }
    }

}
