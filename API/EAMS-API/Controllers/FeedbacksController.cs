using AutoMapper;
using Eams.Core.Domain;
using Eams.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ETMS_API.Controllers
{
    [Route("api/feedbacks")]
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
        /// <summary>
        /// Get all feedbacks
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetFeedbacks()
        {
            var res = await _feedbackRepository.GetFeedbacksAsync();
            return Ok(res);
        }
        /// <summary>
        /// Get feedback by id
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetFeedback(int id)
        {
            var res = await _feedbackRepository.GetByIdAsync(id);
            return Ok(res);
        }
        /// <summary>
        /// Get feedback by event id
        /// </summary>
        [HttpGet]
        [Route("event/{id}")]
        public async Task<IActionResult> GetFeedbackByEvent(int id)
        {
            var res = await _feedbackRepository.GetFeedbackByEventAsync(id);
            return Ok(res);
        }
        /// <summary>
        /// Get feedback by attendee id
        /// </summary>

        [HttpGet]
        [Route("attendee/{id}")]
        public async Task<IActionResult> GetFeedbackByAttendee(int id)
        {
            var res = await _feedbackRepository.GetFeedbackByAttendeeAsync(id);
            return Ok(res);
        }
        /// <summary>
        /// Add a feedback
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddFeedback(Feedback feedback)
        {
            var res = _feedbackRepository.AddFeedbackAsync(feedback);
            return Ok(res);
        }
        /// <summary>
        /// Update a feedback
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> UpdateFeedback(Feedback feedback)
        {
            var res = _feedbackRepository.UpdateFeedbackAsync(feedback);
            return Ok(res);
        }
        /// <summary>
        /// Delete a feedback by id
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            var res = _feedbackRepository.DeleteFeedbackAsync(id);
            return Ok(res);
        }

    }
}
