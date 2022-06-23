using FluentValidation;
using MeetupAPI.Application.Commands.Users;

namespace MeetupAPI.Application.Validators.Users
{
    public class AuthenticateUserCommandValidator : AbstractValidator<AuthenticateUserCommand>
    {
        public AuthenticateUserCommandValidator()
        {
            RuleFor(u => u.Login).NotNull().NotEmpty().MaximumLength(255);
            RuleFor(u => u.Password).NotNull().NotEmpty().MaximumLength(255);
        }
    }
}
