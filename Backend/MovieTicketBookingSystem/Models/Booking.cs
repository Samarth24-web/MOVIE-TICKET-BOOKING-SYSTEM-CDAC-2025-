using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTicketBookingSystem.Models
{
    [Table("Bookings")]
    public class Booking
    {
        [Key]
        public long BookingId { get; set; }

        public long UserId { get; set; }
        public long ShowId { get; set; }

        public decimal TotalAmount { get; set; }
        public string Status { get; set; }

        public DateTime? BookedAt { get; set; }
        public DateTime? CancelledAt { get; set; }
        public DateTime CreatedAt { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("ShowId")]
        public Show Show { get; set; }

        public ICollection<BookingSeat> BookingSeats { get; set; }
    }


}
