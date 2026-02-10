using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTicketBookingSystem.Models
{
    [Table("ShowSeatStatus")]
    public class ShowSeatStatus
    {
        [Key]
        public long ShowSeatStatusId { get; set; }

        public long ShowId { get; set; }
        public long SeatId { get; set; }

        public string Status { get; set; }

        public long? LockedByUserId { get; set; }
        public DateTime? LockStartTime { get; set; }
        public DateTime? LockExpiryTime { get; set; }

        public long? BookingId { get; set; }
        public decimal? PriceAtBooking { get; set; }

        public DateTime LastUpdatedAt { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("ShowId")]
        public Show Show { get; set; }

        [ForeignKey("SeatId")]
        public Seat Seat { get; set; }

        [ForeignKey("LockedByUserId")]
        public User LockedByUser { get; set; }

        [ForeignKey("BookingId")]
        public Booking Booking { get; set; }
    }

}
