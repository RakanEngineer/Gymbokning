using Microsoft.AspNetCore.Identity;

namespace Gymbokning.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Navigation Property
        public ICollection<GymClass> AttendedClasses { get; set; }
        = new List<GymClass>();
    }
}
