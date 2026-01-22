using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTicketBookingSystem.Models
{
    [Table("Genres")]
    public class Genre
    {
        [Key]
        public long GenreId { get; set; }
        public string GenreName { get; set; }
    }

}
