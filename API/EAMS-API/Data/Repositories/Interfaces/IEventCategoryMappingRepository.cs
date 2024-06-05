using ETMS_API.Models;

namespace ETMS_API.Data.Repositories.Interfaces
{
    public interface IEventCategoryMappingRepository
    {
        Task<EventCategoryMapping> GetByIdAsync(int id);
        Task<List<EventCategoryMapping>> GetEventCategoriesAsync();
        Task<EventCategoryMapping> AddEventCategoryMapping(EventCategoryMapping eventCategoryMapping);
        Task<EventCategoryMapping> UpdateEventCategoryMapping(EventCategoryMapping eventCategoryMapping);
        void DeleteEventCategoryMapping(EventCategoryMapping eventCategoryMapping);
    }
}