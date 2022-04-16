using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourismWebsite.Models
{
    public class Booking
    {
        [Key]
        [Column(Order = 0, TypeName = "int")]
        public int BookingID { get; set; }
        [Required]
        [Column(Order = 1, TypeName = "int")]
        public int TouristID { get; set; }
        [Required]
        [Column(Order = 2, TypeName = "int")]
        public int GuideID { get; set; }
        [Required]
        [Column(Order = 3, TypeName = "int")]
        public int DestinationID { get; set; }
        [Required]
        [Column(Order = 4, TypeName = "int")]
        public int AgencyID { get; set; }

        [ForeignKey("TouristID")]
        public Tourist Tourist { get; set; }

        [ForeignKey("GuideID")]
        public Guide Guide { get; set; }

        [ForeignKey("DestinationID")]
        public Destination Destination { get; set; }

        [ForeignKey("AgencyID")]
        public Agency Agency { get; set; }
    }
}
