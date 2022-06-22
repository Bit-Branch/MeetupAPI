using Microsoft.EntityFrameworkCore;
using EventsManagement.Domain.Entities;

namespace EventsManagement.Infrastructure.Persistence
{
    public class EventsDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public EventsDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EventsDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}