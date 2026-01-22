using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTicketBookingSystem.Models
{
    [Table("ScreenTypes")]
    public class ScreenType
    {
        [Key]
        public long ScreenTypeId { get; set; }

        public string TypeName { get; set; }

        public ICollection<Screen> Screens { get; set; }
    }

}
