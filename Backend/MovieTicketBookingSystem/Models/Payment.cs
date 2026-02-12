using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTicketBookingSystem.Models
{
    [Table("Payments")]
    public class Payment
    {
        [Key]
        public long PaymentId { get; set; }

        public long BookingId { get; set; }

        public string? GatewayName { get; set; }
        public string? GatewayOrderId { get; set; }
        public string? GatewayPaymentId { get; set; }
        public string? GatewaySignature { get; set; }

        public decimal? Amount { get; set; }
        public string? Currency { get; set; }
        public string? PaymentMethod { get; set; }
        public string? Status { get; set; }
        public string? FailureReason { get; set; }

        public DateTime? PaidAt { get; set; }
        public DateTime? CreatedAt { get; set; }

        [ForeignKey("BookingId")]
        public Booking? Booking { get; set; }
    }

}
