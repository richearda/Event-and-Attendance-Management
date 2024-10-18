namespace Eams.Core.DTOs.Attendee
{
    public class AttendeeDto
    {
        public int AttendeeId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
    }
}
