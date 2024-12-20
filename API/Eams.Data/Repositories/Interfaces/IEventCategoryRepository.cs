﻿using Eams.Core.Domain;

namespace Eams.Data.Repositories.Interfaces
{
    public interface IEventCategoryRepository
    {
        Task<IEnumerable<EventCategory>> GetAllCategoriesAsync();
        Task<EventCategory> GetCategoryByIdAsync(int categoryId);
        Task AddCategoryAsync(EventCategory category);
        Task UpdateCategoryAsync(int id, EventCategory category);
        Task DeleteCategoryAsync(int categoryId);
    }
}
