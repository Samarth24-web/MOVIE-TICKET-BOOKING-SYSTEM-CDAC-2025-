using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTicketBookingSystem.Models
{
    [Table("SeatTypes")]
    public class SeatType
    {
        [Key]
        public long SeatTypeId { get; set; }

        public string TypeName { get; set; }
        public decimal BasePrice { get; set; }

        public ICollection<Seat> Seats { get; set; }
    }

}
