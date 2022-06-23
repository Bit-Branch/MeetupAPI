using FluentValidation;
using MeetupAPI.Application.Commands.Meetups;

namespace MeetupAPI.Application.Validators.Meetups
{
    public class UpdateMeetupCommandValidator : AbstractValidator<UpdateMeetupCommand>
    {
        public UpdateMeetupCommandValidator()
        {
            RuleFor(m => m.Id).NotNull();
            RuleFor(m => m.Name).NotNull().NotEmpty().MaximumLength(255);
            RuleFor(m => m.Description).NotNull().NotEmpty().MaximumLength(1000);
            RuleFor(m => m.Plan).NotNull().NotEmpty().MaximumLength(1000);
            RuleFor(m => m.Creator).NotNull().NotEmpty().MaximumLength(100);
            RuleFor(m => m.Speaker).NotNull().NotEmpty().MaximumLength(100);
            RuleFor(m => m.MeetupTime).NotNull().NotEmpty();
            RuleFor(m => m.MeetupPlace).NotNull().NotEmpty().MaximumLength(255);
        }
    }
}
