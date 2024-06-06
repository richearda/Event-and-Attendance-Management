using ETMS_API.Data.Repositories.Interfaces;
using ETMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ETMS_API.Data.Repositories
{
    public class AttendeeRepository : IAttendeeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public AttendeeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Attendee> AddAttendee(Attendee attendee)
        {
            await _dbContext.Attendees.AddAsync(attendee);
            _dbContext.SaveChangesAsync();
            return attendee;

        }

        public Task CheckInAsync(int attendeeId)
        {
            throw new NotImplementedException();
        }

        public Task CheckOutAsync(int attendeeId)
        {
            throw new NotImplementedException();
        }

        public async void DeleteAttendee(Attendee attendee)
        {
            _dbContext.Attendees.Remove(attendee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Event>> GetAttendedEventsAsync(int attendeeId)
        {
            //Need to fix later
            var events = await _dbContext.Events.Include(e => e.Attendees)
                                .ToListAsync();
            return events;

        }

        public async Task<IEnumerable<Feedback>> GetAttendeeFeedbacksAsync(int attendeeId)
        {
            //Need to fix later
            var feedbacks = await _dbContext.Feedbacks.ToListAsync();
            return feedbacks;
        }

        public async Task<IEnumerable<Attendee>> GetAttendeesAsync()
        {
            return await _dbContext.Attendees.ToListAsync();
        }

        public async Task<Attendee> GetByIdAsync(int attendeeId)
        {
            var attendee = await _dbContext.Attendees.FindAsync(attendeeId);
            return attendee;
        }

        public async Task<Attendee> UpdateAttendee(Attendee attendee)
        {
            var attendeeToUpdate = await _dbContext.Attendees.FindAsync(attendee.AttendeeId);
            if (attendeeToUpdate != null)
            {
                _dbContext.Entry(attendeeToUpdate).State = EntityState.Modified;
                _dbContext.SaveChangesAsync();              
            }
            return attendeeToUpdate;
        }
    }
}
