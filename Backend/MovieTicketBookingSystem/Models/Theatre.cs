using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTicketBookingSystem.Models
{
    [Table("Theatres")]
    public class Theatre
    {
        [Key]
        public long TheatreId { get; set; }

        public string TheatreName { get; set; }
        public string TheaterAddressUrl { get; set; }
        public string Address { get; set; }

        public long CityId { get; set; }
        public long ManagerId { get; set; }
        public long? ApprovedByAdminId { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; }

        [ForeignKey("ManagerId")]
        public User Manager { get; set; }

        [ForeignKey("ApprovedByAdminId")]
        public User ApprovedByAdmin { get; set; }

        public ICollection<Screen> Screens { get; set; }
    }

}
