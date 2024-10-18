namespace Eams.Core.DTOs.Attendee
{
    public class CreateAttendeeDto
    {
        public string UserId { get; set; }
        public int EventId { get; set; }
        public bool IsCheckedIn { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
