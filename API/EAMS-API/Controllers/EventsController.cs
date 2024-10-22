using AutoMapper;
using Eams.Core.Domain;
using Eams.Core.DTOs.Event;
using Eams.Data.Repositories.Interfaces;
using Eams.Services.Attendee.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ETMS_API.Controllers
{
    [Route("api/events")]
    [ApiController]
    [Produces("application/json")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;
        public EventsController(IEventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }
        /// <summary>
        /// Add an event
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] CreateEventDto eventDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var eventToAdd = _mapper.Map<Event>(eventDto);
            await _eventService.AddEventAsync(eventToAdd, eventDto.EventCategory);
            return Ok();
        }
        /// <summary>
        /// Update an event
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateEvent([FromRoute] int id, [FromBody] UpdateEventDto eventDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var eventToUpdate = _mapper.Map<Event>(eventDto);
            var eventCategoryToUpdate = _mapper.Map<EventCategoryMapping>(eventDto.EventCategory);
            await _eventService.UpdateEventAsync(id, eventToUpdate, eventCategoryToUpdate);
            return Ok(eventDto);
        }
        /// <summary>
        /// Delete an event by id
        /// </summary>
        [HttpDelete]
        [Route("{eventId}")]
        public IActionResult DeleteEvent([FromRoute] int eventId)
        {
            _eventService.DeleteEvent(eventId);
            return Ok();
        }
        /// <summary>
        /// Get an event by id
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetEvent(int id)
        {
            var res = await _eventService.GetEventByIdAsync(id);
            return Ok(res);
        }
        /// <summary>
        /// Get all events
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            var res = await _eventService.GetEvents();
            return Ok(res);
        }
        /// <summary>
        /// Add event feedback
        /// </summary>
        [HttpPost]
        [Route("{id}/feedback")]
        public async Task<IActionResult> AddEventFeedback([FromRoute] int id, [FromBody] Feedback feedback)
        {
            await _eventService.AddEventFeedbackAsync(id, feedback);
            return Ok();
        }
        /// <summary>
        /// Register an attendee for event
        /// </summary>
        [HttpPost]
        [Route("{eventId}/register/{userId}")]
        public async Task<IActionResult> RegisterForEvent([FromRoute] int eventId, string userId)
        {
            await _eventService.RegisterForEventAsync(eventId, userId);
            return Ok();
        }
    }
}
