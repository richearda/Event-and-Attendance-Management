using ETMS_API.Models;

namespace ETMS_API.Data.Repositories.Interfaces
{
    public interface IAttendeeRepository
    {
        Task<Attendee> GetByIdAsync(int attendeeId);
        Task<IEnumerable<Attendee>> GetAttendeesAsync();
        Task<IEnumerable<Event>> GetAttendedEventsAsync(int attendeeId);
        Task<IEnumerable<Feedback>> GetAttendeeFeedbacksAsync(int attendeeId);
        Task<Attendee> AddAttendee(Attendee attendee);
        Task<Attendee> UpdateAttendee(Attendee attendee);
        void DeleteAttendee(Attendee attendee);
        Task CheckInAsync(int attendeeId);
        Task CheckOutAsync(int attendeeId);
    }
}