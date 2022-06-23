using MediatR;
using Microsoft.EntityFrameworkCore;
using MeetupAPI.Application.Commands.Users;
using MeetupAPI.Application.Common.Interfaces;
using MeetupAPI.Application.Services;
using MeetupAPI.Application.Responses;

namespace MeetupAPI.Application.Handlers.CHandlers.Users
{
    public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, AuthenticationResponse>
    {
        private readonly IMeetupsDbContext _context;
        private readonly JwtService _jwtService;

        public AuthenticateUserCommandHandler(IMeetupsDbContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        public async Task<AuthenticationResponse> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Login == request.Login);

            if (user != null)
            {
                bool verified = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);

                if (verified)
                {
                    var token = _jwtService.CreateToken(user);

                    return new AuthenticationResponse { Token = token };
                }
            }

            return null;
        }
    }
}