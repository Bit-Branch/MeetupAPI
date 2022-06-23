using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MeetupAPI.Application.Common.Interfaces;
using MeetupAPI.Application.Queries.Meetups;
using MeetupAPI.Application.Responses;

namespace MeetupAPI.Application.Handlers.QHandlers.Meetups
{
    public class GetAllMeetupsQueryHandler : IRequestHandler<GetAllMeetupsQuery, IEnumerable<GetMeetupResponse>>
    {
        private readonly IMeetupsDbContext _context;
        private readonly IMapper _mapper;

        public GetAllMeetupsQueryHandler(IMeetupsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetMeetupResponse>> Handle(GetAllMeetupsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Meetups
                .ProjectTo<GetMeetupResponse>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
