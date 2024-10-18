namespace Eams.Core.Domain
{
    public class EventCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<EventCategoryMapping> EventCategoryMappings { get; set; }
    }
}
