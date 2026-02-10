using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTicketBookingSystem.Models
{
    [Table("Shows")]
    public class Show
    {
        [Key]
        public long ShowId { get; set; }

        public long MovieId { get; set; }
        public long ScreenId { get; set; }
        public long LanguageId { get; set; }

        public DateTime ShowDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public long? CreatedByManagerId { get; set; }






        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }

        [ForeignKey("ScreenId")]
        public Screen Screen { get; set; }

        [ForeignKey("LanguageId")]
        public Language Language { get; set; }


        [ForeignKey("CreatedByManagerId")]
        public User CreatedByManager { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }

}

