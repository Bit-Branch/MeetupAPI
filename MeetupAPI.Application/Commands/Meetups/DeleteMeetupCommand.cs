using MediatR;

namespace MeetupAPI.Application.Commands.Meetups
{
    public class DeleteMeetupCommand : IRequest<int>
    {
        public int MeetupId { get; set; }
    }
}
