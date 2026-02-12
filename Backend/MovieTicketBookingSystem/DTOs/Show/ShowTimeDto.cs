namespace MovieTicketBookingSystem.DTOs.Show
{
    public class ShowTimeDto
    {
        public long ShowId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime Date { get; set; }
    }

}
