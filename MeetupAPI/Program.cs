using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MeetupAPI.Infrastructure.Persistence;
using MeetupAPI.Infrastructure;
using MeetupAPI.Application;
using MeetupAPI.Application.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(JwtOptions.Position));

builder.Services.AddCors();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer'[space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT"
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

builder.Services.AddApplication(new JwtOptions
{
    Issuer = builder.Configuration["JwtOptions:Issuer"],
    Audience = builder.Configuration["JwtOptions:Audience"],
    SecurityKey = builder.Configuration["JwtOptions:SecurityKey"]
});

builder.Services.AddPersistence(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<MeetupsDbContext>();
    context.Database.Migrate();
}

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(source =>
{
    source
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
}
);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
