using MediatR;
using MeetupAPI.Application.Responses;

namespace MeetupAPI.Application.Commands.Users
{
    public class AuthenticateUserCommand : IRequest<AuthenticationResponse>
    {
        public string Login { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
