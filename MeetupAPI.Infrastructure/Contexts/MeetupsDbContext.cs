using Microsoft.EntityFrameworkCore;
using MeetupAPI.Domain.Entities;
using MeetupAPI.Application.Common.Interfaces;
using MeetupAPI.Domain.Constants;

namespace MeetupAPI.Infrastructure.Persistence
{
    public class MeetupsDbContext : DbContext, IMeetupsDbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Meetup> Meetups { get; set; }

        public MeetupsDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeetupsDbContext).Assembly);

            modelBuilder.Entity<User>().HasData(new User 
            { 
                Id = 1,
                Login = "admin",
                PasswordHash = "$2a$11$ryrrT9gOJR0ySA5NsIlZJOUNcBSFpQQGEYWL5rlOpNKkipsWpvyea",
                Role = Roles.Admin
            });

            modelBuilder.Entity<Meetup>().HasData(new Meetup
            {
                Id = 1,
                Name = "Angular Developement",
                Description = "We will talk about Angular!",
                Plan = "1. Angular 2. DI",
                Creator = "Alex Inkin",
                Speaker = "Alex Inkin",
                MeetupTime = DateTimeOffset.Parse("2022-06-23T12:00:00.000Z"),
                MeetupPlace = "medium.com"
            });

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
                            entry.Entity.CreatedDate = DateTimeOffset.UtcNow;

                            break;
                        } 

                    case EntityState.Modified:
                        {
                            entry.Entity.ModifiedDate = DateTimeOffset.UtcNow;

                            break;
                        } 
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}