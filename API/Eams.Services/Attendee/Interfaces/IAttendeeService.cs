

using Eams.Core.Domain;
using Eams.Core.DTOs.Attendee;

namespace Eams.Services.Attendee.Interfaces
{
    public interface IAttendeeService
    {
        Task<Eams.Core.Domain.Attendee> GetAttendeeByIdAsync(int id);
        Task<IEnumerable<Eams.Core.Domain.Attendee>> GetAttendeesAsync();
        Task<IEnumerable<AttendedEventsDto>> GetAttendedEventsAsync(string userId);
        Task<IEnumerable<Feedback>> GetAttendeeFeedbacksAsync(string userId);
        Task<Eams.Core.Domain.Attendee> AddAttendee(Eams.Core.Domain.Attendee attendee);
        Task<Eams.Core.Domain.Attendee> UpdateAttendee(int attendeeId, Eams.Core.Domain.Attendee attendee);
        void DeleteAttendee(int attendeeId);
        Task CheckInAsync(int attendeeId);
        Task CheckOutAsync(int attendeeId);
    }
}
