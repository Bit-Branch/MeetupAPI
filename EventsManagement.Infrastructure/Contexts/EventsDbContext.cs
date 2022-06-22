using Microsoft.EntityFrameworkCore;
using EventsManagement.Domain.Entities;
using EventsManagement.Application.Common.Interfaces;

namespace EventsManagement.Infrastructure.Persistence
{
    public class EventsDbContext : DbContext, IEventsDbContext
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

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        {
                            entry.Entity.CreatedDate = DateTime.Now;

                            break;
                        } 

                    case EntityState.Modified:
                        {
                            entry.Entity.ModifiedDate = DateTime.Now;

                            break;
                        } 
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}