namespace MovieTicketBookingSystem.DTOs.Booking
{
    public class CreateBookingDto
    {
        public long UserId { get; set; }
        public long ShowId { get; set; }
        public List<SelectedSeatDto> Seats { get; set; }
    }
}
