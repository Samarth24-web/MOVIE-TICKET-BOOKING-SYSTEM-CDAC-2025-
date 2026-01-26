namespace MovieTicketBookingSystem.DTOs.Show
{
    public class ShowDto
    {
        public long ShowId { get; set; }
        public long MovieId { get; set; }
        public long ScreenId { get; set; }
        public DateTime ShowDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }

}
