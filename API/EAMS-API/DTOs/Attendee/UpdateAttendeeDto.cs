namespace ETMS_API.DTOs.Attendee
{
    public class UpdateAttendeeDto
    {
        public int AttendeeId { get; set; }
        public string UserId { get; set; }
        public int EventId { get; set; }
        public bool IsCheckedIn { get; set; }
        public DateTime? CheckInTime { get; set; }
    }
}
