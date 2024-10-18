using Eams.Core.Domain;
using Eams.Core.DTOs.EventCategory;

namespace Eams.Data.Repositories.Interfaces
{
    public interface IEventRepository
    {
        Task<Event> GetByIdAsync(int eventId);
        Task<IEnumerable<Event>> GetEvents();
        Task<IEnumerable<Attendee>> GetEventAttendees(int eventId);
        Task<IEnumerable<Feedback>> GetEventFeedbacksAsync(int eventId);
        Task<IEnumerable<Event>> GetUpcomingEventsAsync();
        Task<IEnumerable<Event>> GetPastEventsAsync();
        Task RegisterForEventAsync(int eventId, string userId);
        Task<Feedback> AddEventFeedbackAsync(int eventId, Feedback feedback);
        Task<Event> AddEventAsync(Event @event, CreateEventCategoryMappingDto eventCategory);
        Task<Event> UpdateEventAsync(int eventId, Event @event, EventCategoryMapping eventCategory);
        void DeleteEvent(int eventId);
    }
}
