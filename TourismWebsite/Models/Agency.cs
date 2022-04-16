using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourismWebsite.Models
{
    public class Agency
    {
        [Key]
        [Column(Order = 0, TypeName = "int")]
        public int AgencyID { get; set; }

        [Required]
        [Column(Order = 1, TypeName = "varchar(50)")]
        public string AgencyName { get; set; }

        [Required]
        [Column(Order = 2, TypeName = "varchar(50)")]
        public string AgencyHeadOffice { get; set; }

        [Required]
        [Column(Order = 3, TypeName = "int")]
        public int AgencyContact { get; set; }

        [Required]
        [Column(Order = 4, TypeName = "int")]
        public int AgencyRatings { get; set; }

        public IEnumerable<Booking> Bookings { get; set; }
    }
}
