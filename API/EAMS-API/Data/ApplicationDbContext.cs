using ETMS_API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ETMS_API.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<EventCategoryMapping> EventCategoriesMappings { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<EventCategory>()
                .HasKey(e => e.CategoryId);

            builder.Entity<Event>()
                .HasKey(e => e.EventId);

            builder.Entity<EventCategoryMapping>()
            .HasKey(e => new { e.EventId, e.CategoryId });

            builder.Entity<EventCategoryMapping>()
                .HasOne(ec => ec.Event)
                .WithMany(e => e.EventCategoryMappings)
                .HasForeignKey(ec => ec.EventId);

            builder.Entity<EventCategoryMapping>()
                .HasOne(ec => ec.Category)
                .WithMany(c => c.EventCategoryMappings)
                .HasForeignKey(ec => ec.CategoryId);
            builder.Entity<Attendee>()
                .HasOne(a => a.User)
                .WithMany(u => u.AttendedEvents)
                .HasForeignKey(a => a.UserId);

            builder.Entity<Feedback>()
                .HasKey(f => f.FeedbackId);
        }
    }
}
