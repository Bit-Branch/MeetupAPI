using MediatR;
using AutoMapper;
using MeetupAPI.Application.Commands.Meetups;
using MeetupAPI.Application.Common.Interfaces;
using MeetupAPI.Domain.Entities;

namespace MeetupAPI.Application.Handlers.CHandlers.Meetups
{
    public class CreateMeetupCommandHandler : IRequestHandler<CreateMeetupCommand, int>
    {
        private readonly IMeetupsDbContext _context;
        private readonly IMapper _mapper;

        public CreateMeetupCommandHandler(IMeetupsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateMeetupCommand request, CancellationToken cancellationToken)
        {
            var meetup = _mapper.Map<Meetup>(request);

            await _context.Meetups.AddAsync(meetup);

            await _context.SaveChangesAsync(cancellationToken);

            return meetup.Id;
        }
    }
}
