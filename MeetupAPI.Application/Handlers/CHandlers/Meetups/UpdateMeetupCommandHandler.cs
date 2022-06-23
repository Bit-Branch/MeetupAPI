using MediatR;
using AutoMapper;
using MeetupAPI.Application.Commands.Meetups;
using MeetupAPI.Application.Common.Interfaces;
using MeetupAPI.Domain.Entities;

namespace MeetupAPI.Application.Handlers.CHandlers.Meetups
{
    public class UpdateMeetupCommandHandler : IRequestHandler<UpdateMeetupCommand, Meetup?>
    {
        private readonly IMeetupsDbContext _context;
        private readonly IMapper _mapper;

        public UpdateMeetupCommandHandler(IMeetupsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Meetup?> Handle(UpdateMeetupCommand request, CancellationToken cancellationToken)
        {
            var existingMeetup = _context.Meetups.FirstOrDefault(m => m.Id == request.Id);

            if (existingMeetup != null)
            {
                _mapper.Map(request, existingMeetup);

                _context.Meetups.Update(existingMeetup);

                await _context.SaveChangesAsync(cancellationToken);
            }

            return existingMeetup;
        }
    }
}
