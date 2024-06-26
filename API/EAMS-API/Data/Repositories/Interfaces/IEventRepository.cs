﻿using ETMS_API.DTOs.EventCategory;
using ETMS_API.Models;

namespace ETMS_API.Data.Repositories.Interfaces
{
    public interface IEventRepository
    {
        Task<Event> GetByIdAsync(int eventId);
        Task<IEnumerable<Event>> GetEvents();
        Task<IEnumerable<Attendee>> GetEventAttendees(int eventId);
        Task<IEnumerable<Feedback>> GetEventFeedbacksAsync(int eventId);
        Task<IEnumerable<Event>> GetUpcomingEventsAsync();
        Task<IEnumerable<Event>> GetPastEventsAsync();
        Task<bool> RegisterForEventAsync(int eventId, string userId);
        Task AddFeedbackAsync(int eventId, string userId, string comment, int rating);
        Task<Event> AddEventAsync(Event @event, CreateEventCategoryMappingDto eventCategory);
        Task<Event> UpdateEventAsync(int eventId, Event @event, EventCategoryMapping eventCategory);
        void DeleteEvent(int eventId);
    }
}
