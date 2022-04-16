using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourismWebsite.Models
{
    public class Destination
    {
        [Key]
        [Column(Order = 0, TypeName = "int")]
        public int DestinationID { get; set; }

        [Required]
        [Column(Order = 1, TypeName = "varchar(50)")]
        public string DestinationName { get; set; }

        [Required]
        [Column(Order = 2, TypeName = "varchar(50)")]
        public string DestinationLocation { get; set; }

        [Required]
        [Column(Order = 3, TypeName = "varchar(200)")]
        public string DestinationDescription { get; set; }

        [Required]
        [Column(Order = 4, TypeName = "int")]
        public int DestinationPackage { get; set; }

        public IEnumerable<Booking> Bookings { get; set; }

    }
}
