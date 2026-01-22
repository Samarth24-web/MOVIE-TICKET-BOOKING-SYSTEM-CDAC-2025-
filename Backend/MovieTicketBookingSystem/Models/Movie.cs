using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTicketBookingSystem.Models
{
    [Table("Movies")]
    public class Movie
    {
        [Key]
        public long MovieId { get; set; }

        public string Title { get; set; }
        public int Duration { get; set; }
        public decimal? Rating { get; set; }
        public string Description { get; set; }
        public DateTime? ReleaseDate { get; set; }

        public ICollection<MovieGenreMap> MovieGenres { get; set; }
        public ICollection<MovieLanguageMap> MovieLanguages { get; set; }
    }

}
