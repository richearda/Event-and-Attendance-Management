using ETMS_API.Models;

namespace ETMS_API.Data.Repositories.Interfaces
{
    public interface IAttendeeRepository
    {
        Task<Attendee> GetByIdAsync(int id);
        Task<List<Attendee>> GetAttendeesAsync();
        Task<List<Event>> GetAttendedEventsAsync(int id);
        Task<List<Feedback>> GetAttendeeFeedbacksAsync(int id);
        Task<Attendee> AddAttendee(Attendee attendee);
        Task<Attendee> UpdateAttendee(Attendee attendee);
        void DeleteAttendee(Attendee attendee);
    }
}