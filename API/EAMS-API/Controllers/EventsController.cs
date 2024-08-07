﻿using AutoMapper;
using ETMS_API.Data.Repositories.Interfaces;
using ETMS_API.DTOs.Event;
using ETMS_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        public EventsController(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] CreateEventDto eventDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var eventToAdd = _mapper.Map<Event>(eventDto);
            await _eventRepository.AddEventAsync(eventToAdd,eventDto.EventCategory);
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateEvent([FromRoute] int id, [FromBody] UpdateEventDto eventDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var eventToUpdate = _mapper.Map<Event>(eventDto);
            var eventCategoryToUpdate = _mapper.Map<EventCategoryMapping>(eventDto.EventCategory);
            await _eventRepository.UpdateEventAsync(id, eventToUpdate, eventCategoryToUpdate);
            return Ok(eventDto);
        }

        [HttpDelete]
        [Route("{eventId}")]
        public IActionResult DeleteEvent([FromRoute] int eventId)
        {
            _eventRepository.DeleteEvent(eventId);
            return Ok();
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetEvent(int id)
        {
            var res = await _eventRepository.GetByIdAsync(id);
            return Ok(res);
        }
        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            var res =await _eventRepository.GetEvents();
            return Ok(res);
        }
        [HttpPost]
        [Route("{id}/Feedback")]
        public async Task<IActionResult> AddEventFeedback([FromRoute] int id, [FromBody] Feedback feedback)
        {
             await _eventRepository.AddEventFeedbackAsync(id, feedback);
            return Ok();
        }
        [HttpPost]
        [Route("{eventId}/Register/{userId}")]
        public async Task<IActionResult> RegisterForEvent([FromRoute] int eventId, string userId)
        {
            await _eventRepository.RegisterForEventAsync(eventId, userId);
            return Ok();
        }
    }
}
