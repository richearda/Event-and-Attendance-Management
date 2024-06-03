namespace ETMS_API.Models
{
    public class Feedback
    {
        public int FeedbackId { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
