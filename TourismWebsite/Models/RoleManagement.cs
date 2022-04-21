using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace TourismWebsite.Models
{
    public class RoleManagement
    {
        public IdentityRole Role { get; set; }
        public ICollection<IdentityUser> Members { get; set; }
        public ICollection<IdentityUser> NonMembers { get; set; }
    }
}
