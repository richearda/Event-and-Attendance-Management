using ETMS_API.Data.Repositories.Interfaces;
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
        public async Task<Event> AddEvent(Event @event)
        {
             await _dbContext.Events.AddAsync(@event);
            _dbContext.SaveChangesAsync();
            return @event;
        }

        public Task AddFeedbackAsync(int eventId, string userId, string comment, int rating)
        {
            throw new NotImplementedException();
        }

        public void DeleteEvent(Event @event)
        {
            _dbContext.Events.Remove(@event);
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

        public async Task<Event> UpdateEvent(Event @event)
        {
            var evntToUpdate = await _dbContext.Events.FindAsync(@event.EventId);
            _dbContext.Entry(evntToUpdate).State = EntityState.Modified;
            _dbContext.SaveChangesAsync();
            return evntToUpdate;
        }
    }
}
