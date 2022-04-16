using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourismWebsite.Models
{
    public class Guide
    {

        [Key]
        [Column(Order = 0, TypeName = "int")]
        public int GuideID { get; set; }

        [Required]
        [Column(Order = 1, TypeName = "varchar(50)")]
        public string GuideName { get; set; }

        [Required]
        [Column(Order = 2, TypeName = "varchar(6)")]
        public string GuideGender { get; set; }

        [Required]
        [Column(Order = 3, TypeName = "int")]
        public int GuideContact { get; set; }

        [Required]
        [Column(Order = 4, TypeName = "int")]
        public int GuidingExperience { get; set; }

        public IEnumerable<Booking> Bookings { get; set; }


    }
}
