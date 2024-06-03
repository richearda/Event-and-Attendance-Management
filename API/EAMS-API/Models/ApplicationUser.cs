using Microsoft.AspNetCore.Identity;

namespace ETMS_API.Models
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public List<Attendee> AttendedEvents { get; set; }
    }
}
