using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTicketBookingSystem.Models
{
    [Table("MovieGenreMap")]
    public class MovieGenreMap
    {
        [Key, Column(Order = 1)]
        public long MovieId { get; set; }

        [Key, Column(Order = 2)]
        public long GenreId { get; set; }

        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }

        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
    }

}
