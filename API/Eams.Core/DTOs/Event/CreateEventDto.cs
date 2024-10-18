using Eams.Core.DTOs.EventCategory;

namespace Eams.Core.DTOs.Event
{
    public class CreateEventDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Location { get; set; }
        public string OrganizerId { get; set; }
        public int Capacity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public CreateEventCategoryMappingDto EventCategory { get; set; }
    }
}
