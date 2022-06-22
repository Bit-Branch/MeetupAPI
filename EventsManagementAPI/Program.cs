using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using EventsManagement.Infrastructure.Persistence;
using EventsManagement.Infrastructure;
using EventsManagement.Application;
using EventsManagement.Application.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(JwtSettings.Position));

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddApplication(new JwtSettings
{
    Issuer = builder.Configuration["JwtSettings:Issuer"],
    Audience = builder.Configuration["JwtSettings:Audience"],
    SecurityKey = builder.Configuration["JwtSettings:SecurityKey"]
});

builder.Services.AddPersistence(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<EventsDbContext>();
    context.Database.Migrate();
}

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
