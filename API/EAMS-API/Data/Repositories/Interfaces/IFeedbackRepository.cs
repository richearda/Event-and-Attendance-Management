using ETMS_API.Models;

namespace ETMS_API.Data.Repositories.Interfaces
{
    public interface IFeedbackRepository
    {
        Task<Feedback> GetByIdAsync(int feedbackId);
        Task<IEnumerable<Feedback>> GetFeedbacksAsync();
        Task AddFeedbackAsync(Feedback feedback);
        Task UpdateFeedbackAsync(Feedback feedback);
        Task DeleteFeedbackAsync(int feedbackId);
        Task<IEnumerable<Feedback>> GetFeedbackByEventAsync(int eventId);
        Task<IEnumerable<Feedback>> GetFeedbackByAttendeeAsync(int attendeeId);
    }
}
