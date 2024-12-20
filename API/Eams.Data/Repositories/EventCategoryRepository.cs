﻿using Eams.Core.Domain;
using Eams.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Eams.Data.Repositories
{
    public class EventCategoryRepository : IEventCategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public EventCategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddCategoryAsync(EventCategory category)
        {
            await _dbContext.EventCategories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
        }


        public async Task DeleteCategoryAsync(int categoryId)
        {
            var toDelete = _dbContext.EventCategories.Find(categoryId);
            _dbContext.EventCategories.Remove(toDelete);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<EventCategory>> GetAllCategoriesAsync()
        {
            return await _dbContext.EventCategories.ToListAsync();
        }

        public async Task<EventCategory> GetCategoryByIdAsync(int categoryId)
        {
            return await _dbContext.EventCategories.FindAsync(categoryId);
        }

        public async Task UpdateCategoryAsync(int id, EventCategory category)
        {
            var categoryToUpdate = await _dbContext.EventCategories.FindAsync(id);
            categoryToUpdate.CategoryName = category.CategoryName;
            _dbContext.Entry(categoryToUpdate).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

        }

    }
}
