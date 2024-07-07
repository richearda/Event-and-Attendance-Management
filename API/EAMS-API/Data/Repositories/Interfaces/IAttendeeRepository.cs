using ETMS_API.Models;

namespace ETMS_API.Data.Repositories.Interfaces
{
    public interface IAttendeeRepository
    {
        Task<Attendee> GetByIdAsync(int attendeeId);
        Task<IEnumerable<Attendee>> GetAttendeesAsync();
        Task<IEnumerable<Attendee>> GetAttendedEventsAsync(string userId);
        Task<IEnumerable<Feedback>> GetAttendeeFeedbacksAsync(string userId);
        Task<Attendee> AddAttendee(Attendee attendee);
        Task<Attendee> UpdateAttendee(int attendeeId, Attendee attendee);
        void DeleteAttendee(Attendee attendee);
        Task CheckInAsync(int attendeeId);
        Task CheckOutAsync(int attendeeId);
    }
}