using AutoMapper;
using ETMS_API.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class FeedbacksController : ControllerBase
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IMapper _mapper;

        public FeedbacksController(IFeedbackRepository feedbackRepository, IMapper mapper)
        {
            _feedbackRepository = feedbackRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetFeedbacks()
        {
            var res = await _feedbackRepository.GetFeedbacksAsync();
            return Ok(res);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetFeedback(int id)
        {
            var res = await _feedbackRepository.GetByIdAsync(id);
            return Ok(res);
        }
        [HttpGet]
        [Route("event/{id}")]
        public async Task<IActionResult> GetFeedbackByEvent(int id)
        {
            var res = await _feedbackRepository.GetFeedbackByEventAsync(id);
            return Ok(res);
        }
        [HttpGet]
        [Route("attendee/{id}")]
        public async Task<IActionResult> GetFeedbackByAttendee(int id)
        {
            var res = await _feedbackRepository.GetFeedbackByAttendeeAsync(id);
            return Ok(res);
        }

    }
}
