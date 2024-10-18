namespace Eams.Core.Domain
{
    public class Event
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Location { get; set; }
        public string OrganizerId { get; set; }
        public ApplicationUser Organizer { get; set; }
        public int Capacity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public List<Attendee> Attendees { get; set; }
        public List<EventCategoryMapping> EventCategoryMappings { get; set; }
        public List<Feedback> Feedbacks { get; set; }
    }
}
