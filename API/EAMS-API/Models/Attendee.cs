namespace ETMS_API.Models
{
    public class Attendee
    {
        public int AttendeeId { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public bool IsCheckedIn { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
