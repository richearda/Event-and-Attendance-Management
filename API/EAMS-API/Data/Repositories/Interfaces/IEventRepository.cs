using ETMS_API.Models;

namespace ETMS_API.Data.Repositories.Interfaces
{
    public interface IEventRepository
    {
        Task<Event> GetByIdAsync(int id);
        Task<List<Event>> GetEvents();
        Task<List<Attendee> GetEventAttendees(int id);
        Task<List<Feedback> GetEventFeedbacks(int id);
        Task<Event> AddEvent(Event @event);
        Task<Event> UpdateEvent(Event @event);
        void DeleteEvent(Event @event);
    }
}
