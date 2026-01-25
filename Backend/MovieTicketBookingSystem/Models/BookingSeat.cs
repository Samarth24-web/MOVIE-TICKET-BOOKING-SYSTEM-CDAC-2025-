using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTicketBookingSystem.Models
{
        [Table("BookingSeats")]
        public class BookingSeat
        {
            [Key]
            public long BookingSeatId { get; set; }

            public long BookingId { get; set; }

            public long ShowSeatStatusId { get; set; }

            public decimal Price { get; set; }

            [ForeignKey("BookingId")]
            public Booking Booking { get; set; }

            [ForeignKey("ShowSeatStatusId")]
            public ShowSeatStatus ShowSeatStatus { get; set; }
        }


}
