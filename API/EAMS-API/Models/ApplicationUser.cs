using Microsoft.AspNetCore.Identity;

namespace ETMS_API.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public List<Attendee> AttendedEvents { get; set; }
    }
}
