using Microsoft.EntityFrameworkCore;
using EventsManagement.Domain.Entities;

namespace EventsManagement.Application.Common.Interfaces
{
    public interface IEventsDbContext
    {
        DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
