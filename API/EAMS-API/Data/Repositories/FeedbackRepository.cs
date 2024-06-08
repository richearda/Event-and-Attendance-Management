using ETMS_API.Data.Repositories.Interfaces;
using ETMS_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace ETMS_API.Data.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public FeedbackRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddFeedbackAsync(Feedback feedback)
        {
            await _dbContext.Feedbacks.AddAsync(feedback);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteFeedbackAsync(int feedbackId)
        {
            var feedbackToDelete = await _dbContext.Feedbacks.FindAsync(feedbackId);
             _dbContext.Feedbacks.Remove(feedbackToDelete);
           await _dbContext.SaveChangesAsync();
        }

        public async Task<Feedback> GetByIdAsync(int feedbackId)
        {
            return await _dbContext.Feedbacks.FindAsync(feedbackId);
        }

        public async Task<IEnumerable<Feedback>> GetFeedbackByAttendeeAsync(int attendeeId)
        {
            //Need to fix
            var feedbacks = await _dbContext.Feedbacks.ToListAsync();
            return feedbacks;
        }

        public async Task<IEnumerable<Feedback>> GetFeedbackByEventAsync(int eventId)
        {
           return await _dbContext.Feedbacks.Where(f => f.EventId == eventId).ToListAsync();
        }

        public async Task<IEnumerable<Feedback>> GetFeedbacksAsync()
        {
            return await _dbContext.Feedbacks.ToListAsync();
        }

        public async Task UpdateFeedbackAsync(Feedback feedback)
        {
            if (feedback is not null)
            {
                _dbContext.Entry(feedback).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            
        }
    }
}
