namespace MovieTicketBookingSystem.DTOs.Show
{
    public class ShowDetailsDto
    {
        public long ShowId { get; set; }

        public long MovieId { get; set; }
        public string MovieName { get; set; }

        public long ScreenId { get; set; }
        public string ScreenName { get; set; }

        public DateTime ShowDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
