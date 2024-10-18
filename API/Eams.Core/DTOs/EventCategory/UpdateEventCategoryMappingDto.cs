namespace Eams.Core.DTOs.EventCategory
{
    public class UpdateEventCategoryMappingDto
    {
        public int EventCategoryMappingId { get; set; }
        public int EventId { get; set; }
        public int CategoryId { get; set; }
    }
}
