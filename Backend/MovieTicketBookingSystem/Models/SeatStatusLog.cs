using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTicketBookingSystem.Models
{
    [Table("SeatStatusLogs")]
    public class SeatStatusLog
    {
        [Key]
        public long LogId { get; set; }

        public long ShowId { get; set; }
        public long SeatId { get; set; }

        public string OldStatus { get; set; }
        public string NewStatus { get; set; }

        public long? ChangedByUserId { get; set; }
        public string ChangeReason { get; set; }

        public long? BookingId { get; set; }
        public bool IsSystemAction { get; set; }

        public DateTime ChangedAt { get; set; }

        [ForeignKey("ShowId")]
        public Show Show { get; set; }

        [ForeignKey("SeatId")]
        public Seat Seat { get; set; }

        [ForeignKey("ChangedByUserId")]
        public User ChangedByUser { get; set; }

        [ForeignKey("BookingId")]
        public Booking Booking { get; set; }
    }

}
