using MediatR;
using Microsoft.EntityFrameworkCore;
using MeetupAPI.Application.Commands.Users;
using MeetupAPI.Application.Common.Interfaces;
using MeetupAPI.Domain.Entities;
using MeetupAPI.Domain.Constants;

namespace MeetupAPI.Application.Handlers.CHandlers.Users
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, int>
    {
        private readonly IMeetupsDbContext _context;

        public RegisterUserCommandHandler(IMeetupsDbContext context)
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
                    PasswordHash = hashedPassword,
                    Role = Roles.User
                };

                await _context.Users.AddAsync(user);

                await _context.SaveChangesAsync(cancellationToken);
            }

            return user.Id;
        }
    }
}
