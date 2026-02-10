using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTicketBookingSystem.Models
{
    [Table("Seats")]
    public class Seat
    {
        [Key]
        public long SeatId { get; set; }

        public string SeatNumber { get; set; }
        public long SeatRowId { get; set; }
        public long SeatTypeId { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("SeatRowId")]
        public SeatRow SeatRow { get; set; }

        [ForeignKey("SeatTypeId")]
        public SeatType SeatType { get; set; }
    }

}
