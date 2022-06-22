using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EventsManagement.Infrastructure.Persistence;
using EventsManagement.Application.Common.Interfaces;

namespace EventsManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EventsDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), options =>
                {
                    options.EnableRetryOnFailure();
                });
            });

            services.AddTransient<IEventsDbContext, EventsDbContext>();

            return services;
        }
    }
}