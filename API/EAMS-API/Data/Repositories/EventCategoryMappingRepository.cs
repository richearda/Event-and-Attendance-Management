using ETMS_API.Data.Repositories.Interfaces;
using ETMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ETMS_API.Data.Repositories
{
    public class EventCategoryMappingRepository : IEventCategoryMappingRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public EventCategoryMappingRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<EventCategoryMapping> AddEventCategoryMapping(EventCategoryMapping eventCategoryMapping)
        {
            await _dbContext.EventCategoriesMappings.AddAsync(eventCategoryMapping);
            await _dbContext.SaveChangesAsync();
            return eventCategoryMapping;
        }

        public void DeleteEventCategoryMapping(EventCategoryMapping eventCategoryMapping)
        {
            _dbContext.EventCategoriesMappings.Remove(eventCategoryMapping);
            _dbContext.SaveChanges();
        }

        public async Task<EventCategoryMapping> GetByIdAsync(int id)
        {
            return await _dbContext.EventCategoriesMappings.FindAsync(id);

        }

        public async Task<IEnumerable<EventCategoryMapping>> GetEventCategoriesAsync()
        {
            return await _dbContext.EventCategoriesMappings.ToListAsync();
        }

        public async Task<EventCategoryMapping> UpdateEventCategoryMapping(EventCategoryMapping eventCategoryMapping)
        {
            _dbContext.Entry(eventCategoryMapping).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return eventCategoryMapping;
        }
    }
}
