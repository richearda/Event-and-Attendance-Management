﻿using AutoMapper;
using Eams.Core.Domain;
using Eams.Core.DTOs.EventCategory;
using Eams.Data.Repositories.Interfaces;
using Eams.Services.Attendee.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ETMS_API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    [Produces("application/json")]
    public class CategoriesController : ControllerBase
    {
        private IEventCategoryService _eventCategoryService;
        private IMapper _mapper;
        public CategoriesController(IEventCategoryService eventCategoryService, IMapper mapper)
        {
            _eventCategoryService = eventCategoryService;
            _mapper = mapper;
        }

        /// <summary>
        /// Add a category
        /// </summary>      
        [HttpPost]
        public async Task<IActionResult> CreateEventCategory([FromBody] CreateEventCategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var categoryToAdd = _mapper.Map<EventCategory>(categoryDto);
            await _eventCategoryService.AddCategoryAsync(categoryToAdd);
            return Ok(categoryToAdd);
        }
        /// <summary>
        /// Update a category
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateEventCategory([FromRoute] int id, [FromBody] UpdateEventCategoryDto categoryDto)
        {

            var categoryToUpdate = _mapper.Map<EventCategory>(categoryDto);
            await _eventCategoryService.UpdateCategoryAsync(id, categoryToUpdate);
            return Ok(categoryToUpdate);
        }
        /// <summary>
        /// Delete a category by id
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteEventCategory(int id)
        {
            _eventCategoryService.DeleteCategoryAsync(id);
            return Ok();
        }
        /// <summary>
        /// Get all categories
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var res = await _eventCategoryService.GetAllCategoriesAsync();
            return Ok(res);
        }
        /// <summary>
        /// Get category by id
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCategory([FromRoute] int id)
        {
            var res = await _eventCategoryService.GetCategoryByIdAsync(id);
            return Ok(res);
        }

    }
}
