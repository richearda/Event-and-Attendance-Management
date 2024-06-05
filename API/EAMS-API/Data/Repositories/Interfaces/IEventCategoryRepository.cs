using ETMS_API.Models;

namespace ETMS_API.Data.Repositories.Interfaces
{
    public interface IEventCategoryRepository
    {
        Task<IEnumerable<EventCategory>> GetAllCategoriesAsync();
        Task<EventCategory> GetCategoryByIdAsync(int categoryId);
        Task AddCategoryAsync(EventCategory category);
        Task UpdateCategoryAsync(EventCategory category);
        Task DeleteCategoryAsync(int categoryId);
    }
}
