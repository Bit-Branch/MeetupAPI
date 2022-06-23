using MediatR;
using AutoMapper;
using MeetupAPI.Application.Common.Interfaces;
using MeetupAPI.Application.Queries.Meetups;
using MeetupAPI.Application.Responses;
using MeetupAPI.Domain.Entities;

namespace MeetupAPI.Application.Handlers.QHandlers.Meetups
{
    public class GetMeetupQueryHandler : IRequestHandler<GetMeetupQuery, GetMeetupResponse?>
    {
        private readonly IMeetupsDbContext _context;
        private readonly IMapper _mapper;

        public GetMeetupQueryHandler(IMeetupsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetMeetupResponse?> Handle(GetMeetupQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<Meetup, GetMeetupResponse>(await _context.Meetups.FindAsync(request.MeetupId));
        }
    }
}
