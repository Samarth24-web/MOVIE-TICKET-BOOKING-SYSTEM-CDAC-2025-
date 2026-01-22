using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTicketBookingSystem.Models
{
    [Table("TheatreManagerRequests")]
    public class TheatreManagerRequest
    {
        [Key]
        public long RequestId { get; set; }

        public long UserId { get; set; }
        public long CityId { get; set; }

        public string TheatreName { get; set; }
        public string TheaterAddressUrl { get; set; }
        public string Address { get; set; }

        public string GovtIdType { get; set; }
        public string GovtIdNumber { get; set; }
        public string ProofDocUrl { get; set; }

        public string Status { get; set; }
        public long? ReviewedByAdminId { get; set; }

        public string RejectionReason { get; set; }
        public DateTime RequestedAt { get; set; }
        public DateTime? ReviewedAt { get; set; }

        [ForeignKey("UserId")]
        public User RequestedByUser { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; }

        [ForeignKey("ReviewedByAdminId")]
        public User ReviewedByAdmin { get; set; }
    }



}
