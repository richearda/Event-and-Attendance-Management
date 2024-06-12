using ETMS_API.Data.Repositories.Interfaces;
using ETMS_API.DTOs.EventCategory;
using ETMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ETMS_API.Data.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _dbContext;       
        public EventRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext; 
           
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

        public Task AddFeedbackAsync(int eventId, string userId, string comment, int rating)
        {
            throw new NotImplementedException();
        }

        public async void DeleteEvent(Event @event)
        {
            _dbContext.Events.Remove(@event);
            await _dbContext.SaveChangesAsync();
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

        public Task<IEnumerable<Event>> GetPastEventsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Event>> GetUpcomingEventsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegisterForEventAsync(int eventId, string userId)
        {
            throw new NotImplementedException();
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
