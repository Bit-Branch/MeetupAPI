using FluentValidation;
using MeetupAPI.Application.Commands.Users;

namespace MeetupAPI.Application.Validators.Users
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(u => u.Login).NotNull().NotEmpty().MaximumLength(255);
            RuleFor(u => u.Password).NotNull().NotEmpty().MaximumLength(255);
            RuleFor(u => u.ConfirmPassword).Equal(u => u.Password);
        }
    }
}
