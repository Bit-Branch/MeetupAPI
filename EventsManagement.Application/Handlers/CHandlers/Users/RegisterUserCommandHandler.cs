using MediatR;
using Microsoft.EntityFrameworkCore;
using EventsManagement.Application.Commands.Users;
using EventsManagement.Application.Common.Interfaces;
using EventsManagement.Domain.Entities;

namespace EventsManagement.Application.Handlers.CHandlers.Users
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, int>
    {
        private readonly IEventsDbContext _context;

        public RegisterUserCommandHandler(IEventsDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Login == request.Login);

            if (user == null)
            {
                var salt = BCrypt.Net.BCrypt.GenerateSalt();

                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password, salt);

                user = new User
                {
                    Login = request.Login,
                    PasswordHash = hashedPassword
                };

                await _context.Users.AddAsync(user);

                await _context.SaveChangesAsync(cancellationToken);
            }

            return user.Id;
        }
    }
}
