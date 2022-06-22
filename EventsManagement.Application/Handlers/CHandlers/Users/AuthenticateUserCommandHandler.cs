using MediatR;
using Microsoft.EntityFrameworkCore;
using EventsManagement.Application.Commands.Users;
using EventsManagement.Application.Common.Interfaces;
using EventsManagement.Application.Responses;
using EventsManagement.Application.Services;

namespace EventsManagement.Application.Handlers.CHandlers.Users
{
    public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, AuthenticationResponse>
    {
        private readonly IEventsDbContext _context;
        private readonly JwtService _jwtService;

        public AuthenticateUserCommandHandler(IEventsDbContext context)
        {
            _context = context;
        }

        public async Task<AuthenticationResponse> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Login == request.Login);

            if (user != null)
            {
                bool verified = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);

                if (verified)
                {
                    var token = _jwtService.CreateToken(user.Id.ToString(), user.Login);

                    return new AuthenticationResponse { Token = token };
                }
            }

            return null;
        }
    }
}