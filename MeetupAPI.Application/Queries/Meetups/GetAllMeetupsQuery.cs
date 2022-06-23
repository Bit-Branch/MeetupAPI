using MediatR;
using MeetupAPI.Application.Responses;

namespace MeetupAPI.Application.Queries.Meetups
{
    public class GetAllMeetupsQuery : IRequest<IEnumerable<GetMeetupResponse>>
    {
    }
}
