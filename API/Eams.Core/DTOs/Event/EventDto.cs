using Eams.Core.DTOs.Attendee;

namespace Eams.Core.DTOs.Event
{
    public class EventDto
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public TimeOnly Time { get; set; }
        public string Location { get; set; }
        public string Organizer { get; set; }
        public ICollection<AttendeeDto> Attendees { get; set; }
    }
}
