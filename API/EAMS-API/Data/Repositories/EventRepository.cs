using ETMS_API.Data.Repositories.Interfaces;
using ETMS_API.DTOs.EventCategory;
using ETMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ETMS_API.Data.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IAttendeeRepository _attendeeRepository;
        
        public EventRepository(ApplicationDbContext dbContext, IFeedbackRepository feedbackRepository, IAttendeeRepository attendeeRepository)
        {
            _dbContext = dbContext; 
            _feedbackRepository = feedbackRepository;
            _attendeeRepository = attendeeRepository;
           
        }
        public async Task<Event> AddEventAsync(Event @event, CreateEventCategoryMappingDto eventCategory)
        {          
            await _dbContext.Events.AddAsync(@event);
            await _dbContext.SaveChangesAsync();

            var eventCategoryMapping = new EventCategoryMapping
            {
                EventId = @event.EventId,
                CategoryId = eventCategory.CategoryId
            };
            //Insert the Id of Event and Category in EventCategoryMapping table.
            await _dbContext.EventCategoriesMappings.AddAsync(eventCategoryMapping);
            await _dbContext.SaveChangesAsync();

            return @event;
        }

        public async Task<Feedback> AddEventFeedbackAsync(int eventId, Feedback feedback)
        {
            var @event = await _dbContext.Events.FindAsync(eventId);
            if(@event is not null)
            {
                @event.Feedbacks.Add(feedback);

            }
            await _dbContext.SaveChangesAsync();
            return feedback;
        }

        public void DeleteEvent(int eventId)
        {
            var eventToDelete =  _dbContext.Events.Find(eventId);
            _dbContext.Events.Remove(eventToDelete);
            _dbContext.SaveChanges();
        }

        public async Task<Event> GetByIdAsync(int eventId)
        {
            var evnt = await _dbContext.Events.FindAsync(eventId);
            return evnt;
        }

        public async Task<IEnumerable<Attendee>> GetEventAttendees(int eventId)
        {
            var attendees = await _dbContext.Attendees.Where(e => e.EventId == eventId).ToListAsync();
            return attendees;
        }

        public async Task<IEnumerable<Feedback>> GetEventFeedbacksAsync(int eventId)
        {
            var feedbacks = await _dbContext.Feedbacks.Where(f => f.EventId == eventId).ToListAsync();
            return feedbacks;
        }

        public async Task<IEnumerable<Event>> GetEvents()
        {
            var evnts = await _dbContext.Events.ToListAsync();
            return evnts;
        }

        public async Task<IEnumerable<Event>> GetPastEventsAsync()
        {
           return await _dbContext
                  .Events
                  .Where(e => e.Date.Add(e.Time) < DateTime.Now)
                  .ToListAsync();
        }

        public async Task<IEnumerable<Event>> GetUpcomingEventsAsync()
        {
            return await _dbContext
               .Events
               .Where(e => e.Date.Add(e.Time) > DateTime.Now)
               .ToListAsync();
        }

        public async Task RegisterForEventAsync(int eventId, string userId)
        {
            var attendee = new Attendee
            {
                EventId = eventId,
                UserId = userId
            };
             await _attendeeRepository.AddAttendee(attendee);
            
        }

        public async Task<Event> UpdateEventAsync(int eventId, Event @event, EventCategoryMapping eventCategory)
        {
            var evntToUpdate = await _dbContext.Events
                                       .Include(e => e.EventCategoryMappings)
                                       .FirstOrDefaultAsync(e => e.EventId == eventId);
            if (evntToUpdate != null)
            {
   
                evntToUpdate.Title = @event.Title;
                evntToUpdate.Description = @event.Description;
                evntToUpdate.Date = @event.Date;
                evntToUpdate.Time = @event.Time;
                evntToUpdate.Location = @event.Location;
                evntToUpdate.OrganizerId = @event.OrganizerId;
                evntToUpdate.Capacity = @event.Capacity;

             
                var categoryMappingToUpdate = evntToUpdate.EventCategoryMappings
                                                          .FirstOrDefault(ec => ec.EventCategoryMappingId == eventCategory.EventCategoryMappingId);
                if (categoryMappingToUpdate != null)
                {
                    
                    _dbContext.EventCategoriesMappings.Remove(categoryMappingToUpdate);
                }
                
                    evntToUpdate.EventCategoryMappings.Add(new EventCategoryMapping
                    {
                        CategoryId = eventCategory.CategoryId,
                        EventId = evntToUpdate.EventId
                    });
                            
                
                await _dbContext.SaveChangesAsync();
                }
                return @event;

        }
    }
}
