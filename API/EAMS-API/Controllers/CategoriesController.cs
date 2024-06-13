using AutoMapper;
using ETMS_API.Data.Repositories.Interfaces;
using ETMS_API.DTOs.EventCategory;
using ETMS_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CategoriesController : ControllerBase
    {
        private IEventCategoryRepository _eventCategoryRepository;
        private IMapper _mapper;
        public CategoriesController(IEventCategoryRepository eventCategoryRepository, IMapper mapper)
        {
            _eventCategoryRepository = eventCategoryRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEventCategory([FromBody] CreateEventCategoryDto categoryDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var categoryToAdd = _mapper.Map<EventCategory>(categoryDto);
            await _eventCategoryRepository.AddCategoryAsync(categoryToAdd);
            return Ok(categoryToAdd);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateEventCategory([FromRoute] int id, [FromBody] UpdateEventCategoryDto categoryDto)
        {

            var categoryToUpdate = _mapper.Map<EventCategory>(categoryDto);
            await _eventCategoryRepository.UpdateCategoryAsync(id,categoryToUpdate);
            return Ok(categoryToUpdate);
        }

    }
}
