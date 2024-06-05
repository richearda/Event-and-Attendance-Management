using ETMS_API.Models;

namespace ETMS_API.Data.Repositories.Interfaces
{
    public interface IAttendeeRepository
    {
        Task<Attendee> GetByIdAsync(int id);
        Task<IEnumerable<Attendee>> GetAttendeesAsync();
        Task<IEnumerable<Event>> GetAttendedEventsAsync(int id);
        Task<IEnumerable<Feedback>> GetAttendeeFeedbacksAsync(int id);
        Task<Attendee> AddAttendee(Attendee attendee);
        Task<Attendee> UpdateAttendee(Attendee attendee);
        void DeleteAttendee(Attendee attendee);
    }
}