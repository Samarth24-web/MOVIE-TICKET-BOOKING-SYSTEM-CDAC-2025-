namespace MovieTicketBookingSystem.DTOs.Seat
{
    public class SeatRowDto
    {
        public string RowName { get; set; }
        public int TotalSeats { get; set; }
        public List<SeatDto> Seats { get; set; }
    }

}
