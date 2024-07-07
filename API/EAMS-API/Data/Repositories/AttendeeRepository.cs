using ETMS_API.Data.Repositories.Interfaces;
using ETMS_API.DTOs.Attendee;
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
            await _dbContext.SaveChangesAsync();
            return attendee;
        }

        public async Task CheckInAsync(int attendeeId)
        {
            var toUpdate = await _dbContext.Attendees.Where(a => a.AttendeeId == attendeeId).FirstAsync();
            if(toUpdate is not null) 
            {
                toUpdate.CheckInTime = DateTime.Now;
                _dbContext.Entry(toUpdate).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
        }
        
        public async Task CheckOutAsync(int attendeeId)
        {
            var toUpdate = await _dbContext.Attendees.Where(a => a.AttendeeId == attendeeId).FirstAsync();
            if (toUpdate is not null)
            {
                toUpdate.CheckOutTime = DateTime.Now;
                _dbContext.Entry(toUpdate).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async void DeleteAttendee(Attendee attendee)
        {
            _dbContext.Attendees.Remove(attendee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Attendee>> GetAttendedEventsAsync(string userId)
        {
            //Need to fix later
            var events = await _dbContext.Attendees
                                .Include(e => e.Event)
                                .Where(a => a.UserId == userId)
                                .ToListAsync();
            return events;
            
            
        }

        public async Task<IEnumerable<Feedback>> GetAttendeeFeedbacksAsync(string userId)
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

        public async Task<Attendee> UpdateAttendee(int attendeeId, Attendee attendee)
        {
            var attendeeToUpdate = await _dbContext.Attendees.FindAsync(attendeeId);
            if (attendeeToUpdate is not null)
            {
                attendeeToUpdate.UserId = attendee.UserId;
                attendeeToUpdate.EventId = attendee.EventId;
                attendeeToUpdate.IsCheckedIn = attendee.IsCheckedIn;
                attendeeToUpdate.CheckInTime = attendee.CheckInTime;
                attendeeToUpdate.CheckOutTime = attendee.CheckOutTime;
                
                await _dbContext.SaveChangesAsync();              
            }
            return attendeeToUpdate;
        }
    }
}
