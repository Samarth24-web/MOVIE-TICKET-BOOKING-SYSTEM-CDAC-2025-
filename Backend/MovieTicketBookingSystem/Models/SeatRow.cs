using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTicketBookingSystem.Models
{
    [Table("SeatRows")]
    public class SeatRow
    {
        [Key]
        public long SeatRowId { get; set; }

        public string RowName { get; set; }
        public int RowOrder { get; set; }
        public long ScreenId { get; set; }

        [ForeignKey("ScreenId")]
        public Screen Screen { get; set; }

        public ICollection<Seat> Seats { get; set; }
    }
}
