using AutoMapper;
using Eams.Core.Domain;
using Eams.Core.DTOs.Attendee;
using Eams.Data.Repositories.Interfaces;
using Eams.Services.Attendee.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ETMS_API.Controllers
{
    [Route("api/attendees")]
    [ApiController]
    [Produces("application/json")]
    public class AttendeesController : ControllerBase
    {
        private readonly IAttendeeService _attendeeService;
        private readonly IMapper _mapper;

        public AttendeesController(IAttendeeService attendeeService, IMapper mapper)
        {
            _attendeeService = attendeeService;
            _mapper = mapper;
        }

        /// <summary>
        /// Add an attendee
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateAttendee(CreateAttendeeDto attendee)
        {
            var attendeeModel = _mapper.Map<Attendee>(attendee);
            await _attendeeService.AddAttendee(attendeeModel);
            return Ok(attendeeModel);
        }
        /// <summary>
        /// Update an attendee
        /// </summary>       
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAttendee([FromRoute] int id, UpdateAttendeeDto attendee)
        {
            var attendeeModel = _mapper.Map<Attendee>(attendee);
            await _attendeeService.UpdateAttendee(id, attendeeModel);
            return Ok(attendeeModel);
        }
        /// <summary>
        /// Get all attendees
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAttendees()
        {
            var res = await _attendeeService.GetAttendeesAsync();
            return Ok(res);
        }
        /// <summary>
        /// Get attendee by id
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAttendee([FromRoute] int id)
        {
            var res = await _attendeeService.GetAttendeeByIdAsync(id);
            return Ok(res);
        }
        /// <summary>
        /// Get the feedbacks of specific attendee
        /// </summary>
        [HttpGet]
        [Route("{id}/feedbacks")]
        public async Task<IActionResult> GetAttendeeFeedbacks(string id)
        {
            var res = await _attendeeService.GetAttendeeFeedbacksAsync(id);
            return Ok(res);
        }
        /// <summary>
        /// Get the attended events of a specific attendee
        /// </summary>
        [HttpGet]
        [Route("{id}/events")]
        public async Task<IActionResult> GetAttendedEvents(string id)
        {
            var res = await _attendeeService.GetAttendedEventsAsync(id);
            return Ok(res);
        }
        /// <summary>
        /// Delete an attendee by id
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteAttendee(int id)
        {
            _attendeeService.DeleteAttendee(id);
            return Ok();
        }
    }
}
