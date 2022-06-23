using MediatR;
using MeetupAPI.Application.Responses;

namespace MeetupAPI.Application.Queries.Meetups
{
    public class GetMeetupQuery : IRequest<GetMeetupResponse?>
    {
        public int MeetupId { get; set; }
    }
}
