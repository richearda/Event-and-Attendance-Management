using Eams.Core.Domain;
using Eams.Core.DTOs.EventCategory;
using Eams.Data.Repositories.Interfaces;
using Eams.Services.Attendee.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eams.Services.Attendee
{
    
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<Event> AddEventAsync(Event @event, CreateEventCategoryMappingDto eventCategory)
        {
            return await _eventRepository.AddEventAsync(@event, eventCategory);
        }

        public async Task<Feedback> AddEventFeedbackAsync(int eventId, Feedback feedback)
        {
           return await _eventRepository.AddEventFeedbackAsync(eventId, feedback);
        }

        public void DeleteEvent(int eventId)
        {
            _eventRepository.DeleteEvent(eventId);
        }

        public async Task<IEnumerable<Core.Domain.Attendee>> GetEventAttendees(int eventId)
        {
            return await _eventRepository.GetEventAttendees(eventId);
        }

        public async Task<Event> GetEventByIdAsync(int eventId)
        {
            return await _eventRepository.GetByIdAsync(eventId);
        }

        public async Task<IEnumerable<Feedback>> GetEventFeedbacksAsync(int eventId)
        {
            return await _eventRepository.GetEventFeedbacksAsync(@eventId);
        }

        public async Task<IEnumerable<Event>> GetEvents()
        {
            return await _eventRepository.GetEvents();
        }

        public async Task<IEnumerable<Event>> GetPastEventsAsync()
        {
            return await _eventRepository.GetPastEventsAsync();
        }

        public async Task<IEnumerable<Event>> GetUpcomingEventsAsync()
        {
            return await _eventRepository.GetUpcomingEventsAsync();
        }

        public async Task RegisterForEventAsync(int eventId, string userId)
        {
             await _eventRepository.RegisterForEventAsync(eventId, userId);
        }

        public async Task<Event> UpdateEventAsync(int eventId, Event @event, EventCategoryMapping eventCategory)
        {
            return await _eventRepository.UpdateEventAsync(eventId, @event, eventCategory);
        }
    }
}
