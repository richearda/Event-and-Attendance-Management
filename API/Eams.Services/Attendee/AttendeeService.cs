using Eams.Core.Domain;
using Eams.Core.DTOs.Attendee;
using Eams.Data.Repositories.Interfaces;
using Eams.Services.Attendee.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eams.Services.Attendee
{

    public class AttendeeService : IAttendeeService
    {
        private readonly IAttendeeRepository _attendeeRepository;
        public AttendeeService(IAttendeeRepository attendeeRepository)
        {
            _attendeeRepository = attendeeRepository;
        }

        public Task<Core.Domain.Attendee> AddAttendee(Core.Domain.Attendee attendee)
        {
            throw new NotImplementedException();
        }

        public async Task CheckInAsync(int attendeeId)
        {
            var attendee = _attendeeRepository.GetByIdAsync(attendeeId);
            
            if(attendee == null)
            {
                throw new KeyNotFoundException("Attendee record does not exist.");
            }

            await _attendeeRepository.CheckInAsync(attendeeId);
        }

        public async Task CheckOutAsync(int attendeeId)
        {
            var attendee = _attendeeRepository.GetByIdAsync(attendeeId);

            if (attendee == null)
            {
                throw new KeyNotFoundException("Attendee record does not exist.");
            }

            await _attendeeRepository.CheckOutAsync(attendeeId);
        }

        public void DeleteAttendee(int attendeeId)
        {
            var attendee = _attendeeRepository.GetByIdAsync(attendeeId);
            if(attendee == null)
            {
                throw new KeyNotFoundException("Attendee record does not exist.");
            }

             _attendeeRepository.DeleteAttendee(attendeeId);
        }

        public async Task<IEnumerable<AttendedEventsDto>> GetAttendedEventsAsync(string userId)
        {
            return await _attendeeRepository.GetAttendedEventsAsync(userId);
        }

        public Task<Core.Domain.Attendee> GetAttendeeByIdAsync(int id)
        {
            if(id < 0) { throw new ArgumentOutOfRangeException("id"); }
           return _attendeeRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Feedback>> GetAttendeeFeedbacksAsync(string userId)
        {
           return await _attendeeRepository.GetAttendeeFeedbacksAsync(userId);
        }

        public async Task<IEnumerable<Core.Domain.Attendee>> GetAttendeesAsync()
        {
            return await _attendeeRepository.GetAttendeesAsync();
        }

        public async Task<Core.Domain.Attendee> UpdateAttendee(int attendeeId, Core.Domain.Attendee attendee)
        {
            return await _attendeeRepository.UpdateAttendee(attendeeId, attendee);
        }
    }
}
