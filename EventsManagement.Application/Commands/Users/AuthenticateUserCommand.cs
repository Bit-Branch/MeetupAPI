using MediatR;
using EventsManagement.Application.Responses;

namespace EventsManagement.Application.Commands.Users
{
    public class AuthenticateUserCommand : IRequest<AuthenticationResponse>
    {
        public string Login { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
