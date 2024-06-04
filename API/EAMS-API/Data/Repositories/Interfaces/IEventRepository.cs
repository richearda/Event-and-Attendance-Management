using ETMS_API.Models;

namespace ETMS_API.Data.Repositories.Interfaces
{
    public interface IEventRepository
    {
        Task<Event> GetByIdAsync(int id);
        Task<List<Event>> GetEvents();
        Task<Event> AddEvent(Event @event);
        Task<Event> UpdateEvent(Event @event);
        void DeleteEvent(Event @event);
    }
}
