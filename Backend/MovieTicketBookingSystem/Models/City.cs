using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTicketBookingSystem.Models
{
    [Table("Cities")]
    public class City
    {
        [Key]
        public long CityId { get; set; }

        public string CityName { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Theatre> Theatres { get; set; }
    }

}
