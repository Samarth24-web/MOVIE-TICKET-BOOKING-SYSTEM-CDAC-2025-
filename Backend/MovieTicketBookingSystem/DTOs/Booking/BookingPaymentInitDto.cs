namespace MovieTicketBookingSystem.DTOs.Booking
{
    public class BookingPaymentInitDto
    {
        public long BookingId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}
