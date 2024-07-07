using AutoMapper;
using ETMS_API.Data.Repositories.Interfaces;
using ETMS_API.DTOs.Attendee;
using ETMS_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AttendeesController : ControllerBase
    {
        private readonly IAttendeeRepository _attendeeRepository;
        private readonly IMapper _mapper;

        public AttendeesController(IAttendeeRepository attendeeRepository, IMapper mapper)
        {
            _attendeeRepository = attendeeRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAttendee(CreateAttendeeDto attendee)
        {
            var attendeeModel = _mapper.Map<Attendee>(attendee);
            await _attendeeRepository.AddAttendee(attendeeModel);
            return Ok(attendeeModel);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAttendee([FromRoute] int id, UpdateAttendeeDto attendee)
        {
            var attendeeModel = _mapper.Map<Attendee>(attendee);
            await _attendeeRepository.UpdateAttendee(id,attendeeModel);
            return Ok(attendeeModel);
        }
        [HttpGet]
        public async Task<IActionResult> GetAttendees()
        {
            var res = await _attendeeRepository.GetAttendeesAsync();
            return Ok(res);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAttendee([FromRoute] int id)
        {
            var res = await _attendeeRepository.GetByIdAsync(id);
            return Ok(res);
        }
        [HttpGet]
        [Route("{id}/Feedbacks")]
        public async Task<IActionResult> GetAttendeeFeedbacks(string id)
        {
            var res = await _attendeeRepository.GetAttendeeFeedbacksAsync(id);
            return Ok(res);
        }
    }
}
