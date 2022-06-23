using Microsoft.EntityFrameworkCore;
using MeetupAPI.Domain.Entities;

namespace MeetupAPI.Application.Common.Interfaces
{
    public interface IMeetupsDbContext
    {
        DbSet<User> Users { get; set; }

        DbSet<Meetup> Meetups { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
