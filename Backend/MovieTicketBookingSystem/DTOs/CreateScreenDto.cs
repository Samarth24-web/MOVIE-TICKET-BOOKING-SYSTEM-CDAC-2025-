namespace MovieTicketBookingSystem.DTOs
{
    public class CreateScreenDto
    {
        public string ScreenName { get; set; }
        public long TheatreId { get; set; }
        public long? ScreenTypeId { get; set; }
        public int? TotalSeats { get; set; }
    }

}
