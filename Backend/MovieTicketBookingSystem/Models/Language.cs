using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTicketBookingSystem.Models
{
    [Table("Languages")]
    public class Language
    {
        [Key]
        public long LanguageId { get; set; }
        public string LanguageName { get; set; }
    }

}
