namespace MovieTicketBookingSystem.DTOs
{
    public class CreateSeatRowDto
    {
        public long ScreenId { get; set; }
        public string RowName { get; set; }
        public int NumberOfSeats { get; set; }
    }

}
