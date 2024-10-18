using AutoMapper;
using Eams.Core.Domain;
using Eams.Core.DTOs.Attendee;
using Eams.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Eams.Data.Repositories
{
    public class AttendeeRepository : IAttendeeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public AttendeeRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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
            if (toUpdate is not null)
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

        public async void DeleteAttendee(int id)
        {
            var attendeeToDelete = _dbContext.Attendees.Find(id);
            _dbContext.Attendees.Remove(attendeeToDelete);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AttendedEventsDto>> GetAttendedEventsAsync(string userId)
        {
            //Need to fix later
            var events = await _dbContext.Attendees
                                .Include(e => e.Event)
                                .Where(a => a.UserId == userId)
                                .ToListAsync();
            var attendedEventsDto = _mapper.Map<IEnumerable<AttendedEventsDto>>(events);
            return attendedEventsDto;
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
