using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTicketBookingSystem.Models
{
    [Table("MovieLanguageMap")]
    public class MovieLanguageMap
    {
        [Key, Column(Order = 1)]
        public long MovieId { get; set; }

        [Key, Column(Order = 2)]
        public long LanguageId { get; set; }

        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }

        [ForeignKey("LanguageId")]
        public Language Language { get; set; }
    }

}
