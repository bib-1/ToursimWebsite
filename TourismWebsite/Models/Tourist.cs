using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourismWebsite.Models
{
    public class Tourist
    {
        [Key]
        [Column(Order = 0, TypeName = "int")]
        public int TouristID { get; set; }

        [Required]
        [Column(Order = 1, TypeName = "varchar(50)")]
        public string TouristName { get; set; }

        [Required]
        [Column(Order = 2, TypeName = "varchar(6)")]
        public string TouristGender { get; set; }

        [Required]
        [Column(Order = 3, TypeName = "int")]
        public int TouristAge { get; set; }

        [Required]
        [Column(Order = 4, TypeName = "int")]
        public int TouristContact { get; set; }

        public IEnumerable<Booking> Bookings { get; set; }

    }
}
