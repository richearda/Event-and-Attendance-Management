using ETMS_API.DTOs.Attendee;
using ETMS_API.Models;

namespace ETMS_API.Data.Repositories.Interfaces
{
    public interface IAttendeeRepository
    {
        Task<Attendee> GetByIdAsync(int attendeeId);
        Task<IEnumerable<Attendee>> GetAttendeesAsync();
        Task<IEnumerable<AttendedEventsDto>> GetAttendedEventsAsync(string userId);
        Task<IEnumerable<Feedback>> GetAttendeeFeedbacksAsync(string userId);
        Task<Attendee> AddAttendee(Attendee attendee);
        Task<Attendee> UpdateAttendee(int attendeeId, Attendee attendee);
        void DeleteAttendee(int attendeeId);
        Task CheckInAsync(int attendeeId);
        Task CheckOutAsync(int attendeeId);
    }
}