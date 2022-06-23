using FluentValidation;
using MeetupAPI.Application.Commands.Meetups;

namespace MeetupAPI.Application.Validators.Meetups
{
    public class DeleteMeetupCommandValidator : AbstractValidator<DeleteMeetupCommand>
    {
        public DeleteMeetupCommandValidator()
        {
            RuleFor(m => m.MeetupId).NotNull();
        }
    }
}
