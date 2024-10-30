using Eams.Core.Domain;
using Eams.Data.Repositories.Interfaces;
using Eams.Services.Attendee.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eams.Services.Attendee
{
    public class EventCategoryService : IEventCategoryService
    {
        private readonly IEventCategoryRepository _eventCategoryRepository;
        public EventCategoryService(IEventCategoryRepository eventCategoryRepository)
        {
            _eventCategoryRepository = eventCategoryRepository;
        }
        public async Task AddCategoryAsync(EventCategory category)
        {
            await _eventCategoryRepository.AddCategoryAsync(category);
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            await _eventCategoryRepository.DeleteCategoryAsync(categoryId);
        }

        public async Task<IEnumerable<EventCategory>> GetAllCategoriesAsync()
        {
            return await _eventCategoryRepository.GetAllCategoriesAsync();
        }

        public async Task<EventCategory> GetCategoryByIdAsync(int categoryId)
        {
            return await _eventCategoryRepository.GetCategoryByIdAsync(categoryId);
        }

        public async Task UpdateCategoryAsync(int id, EventCategory category)
        {
            await _eventCategoryRepository.UpdateCategoryAsync(id, category);
        }
    }
}
