using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTicketBookingSystem.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public long UserId { get; set; }

        [Required, MaxLength(150)]
        public string UserName { get; set; }

        [Required, MaxLength(150)]
        public string Email { get; set; }

        [Required, MaxLength(20)]
        public string Phone { get; set; }

        [Required, MaxLength(255)]
        public string Password { get; set; }

        public int RoleId { get; set; }

        public DateTime CreatedAt { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }

}
