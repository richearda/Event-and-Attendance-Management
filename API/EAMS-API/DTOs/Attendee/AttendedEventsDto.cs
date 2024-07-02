namespace ETMS_API.DTOs.Attendee
{
    public class AttendedEventsDto
    {
        public int AttendeeId { get; set; }
        public int EventId { get; set; }
        public string EventTitle { get; set; }
        public string EventDescription { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
        public string Organizer { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
    }
}
