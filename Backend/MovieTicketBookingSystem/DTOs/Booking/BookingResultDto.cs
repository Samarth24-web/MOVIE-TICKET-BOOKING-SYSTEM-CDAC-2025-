namespace MovieTicketBookingSystem.DTOs.Booking
{
    public class BookingResultDto
    {
        public long BookingId { get; set; }
        public decimal TotalAmount { get; set; }
        public string RazorpayOrderId { get; set; }
    }
}
