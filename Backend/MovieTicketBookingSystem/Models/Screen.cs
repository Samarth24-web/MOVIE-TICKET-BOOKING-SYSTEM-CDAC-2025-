using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTicketBookingSystem.Models
{
    [Table("Screens")]
    public class Screen
    {
        [Key]
        public long ScreenId { get; set; }

        public string ScreenName { get; set; }
        public long TheatreId { get; set; }
        public long ScreenTypeId { get; set; }
        public int TotalSeats { get; set; }

        [ForeignKey("TheatreId")]
        public Theatre Theatre { get; set; }

        [ForeignKey("ScreenTypeId")]
        public ScreenType ScreenType { get; set; }

        public ICollection<SeatRow> SeatRows { get; set; }
    }

}
