using Eams.Core.Domain;
using Eams.Core.DTOs.EventCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eams.Services.Attendee.Interfaces
{
    public interface IEventService
    {
        Task<Event> GetEventByIdAsync(int eventId);
        Task<IEnumerable<Event>> GetEvents();
        Task<IEnumerable<Core.Domain.Attendee>> GetEventAttendees(int eventId);
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
