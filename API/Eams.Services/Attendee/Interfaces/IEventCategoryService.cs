using Eams.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eams.Services.Attendee.Interfaces
{
    public interface IEventCategoryService
    {
        Task<IEnumerable<EventCategory>> GetAllCategoriesAsync();
        Task<EventCategory> GetCategoryByIdAsync(int categoryId);
        Task AddCategoryAsync(EventCategory category);
        Task UpdateCategoryAsync(int id, EventCategory category);
        Task DeleteCategoryAsync(int categoryId);
    }
}
