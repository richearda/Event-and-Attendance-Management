using ETMS_API.Models;

namespace ETMS_API.Data.Repositories.Interfaces
{
    public interface IEventRepository
    {
        Task<Event> GetByIdAsync(int id);
        Task<IEnumerable<Event>> GetEvents();
        Task<IEnumerable<Attendee>> GetEventAttendees(int id);
        Task<IEnumerable<Feedback>> GetEventFeedbacks(int id);
        Task<Event> AddEvent(Event @event);
        Task<Event> UpdateEvent(Event @event);
        void DeleteEvent(Event @event);
    }
}
