using ETMS_API.Data.Repositories.Interfaces;
using ETMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ETMS_API.Data.Repositories
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

        public async Task UpdateCategoryAsync(EventCategory category)
        {
            _dbContext.Entry(category).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            
        }
    }
}
