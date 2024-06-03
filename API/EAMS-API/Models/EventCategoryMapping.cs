namespace ETMS_API.Models
{

        public class EventCategoryMapping
        {
            public int EventCategoryMappingId { get; set; }
            public int EventId { get; set; }
            public Event Event { get; set; }
            public int CategoryId { get; set; }
            public EventCategory Category { get; set; }
        }
    
}
