using MediatR;

namespace MeetupAPI.Application.Commands.Users
{
    public class RegisterUserCommand : IRequest<int>
    {
        public string Login { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
