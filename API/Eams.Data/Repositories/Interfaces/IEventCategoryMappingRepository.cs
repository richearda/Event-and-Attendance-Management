using Eams.Core.Domain;

namespace Eams.Data.Repositories.Interfaces
{
    public interface IEventCategoryMappingRepository
    {
        Task<EventCategoryMapping> GetByIdAsync(int id);
        Task<IEnumerable<EventCategoryMapping>> GetEventCategoriesAsync();
        Task<EventCategoryMapping> AddEventCategoryMapping(EventCategoryMapping eventCategoryMapping);
        Task<EventCategoryMapping> UpdateEventCategoryMapping(EventCategoryMapping eventCategoryMapping);
        void DeleteEventCategoryMapping(EventCategoryMapping eventCategoryMapping);
    }
}