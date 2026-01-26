namespace MovieTicketBookingSystem.DTOs.Show
{
    public class CreateShowDto
    {
        public long MovieId { get; set; }
        public long ScreenId { get; set; }
        public long LanguageId { get; set; }
        public DateTime ShowDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public long CreatedByManagerId { get; set; }
    }

}
