using MediatR;
using MeetupAPI.Application.Commands.Meetups;
using MeetupAPI.Application.Common.Interfaces;

namespace MeetupAPI.Application.Handlers.CHandlers.Meetups
{
    public class DeleteMeetupCommandHandler : IRequestHandler<DeleteMeetupCommand, int>
    {
        private readonly IMeetupsDbContext _context;

        public DeleteMeetupCommandHandler(IMeetupsDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteMeetupCommand request, CancellationToken cancellationToken)
        {
            var meetupToRemove = _context.Meetups.FirstOrDefault(m => m.Id == request.MeetupId);

            if (meetupToRemove == null)
            {
                return -1;
            }

            _context.Meetups.Remove(meetupToRemove);

            await _context.SaveChangesAsync(cancellationToken);

            return meetupToRemove.Id;
        }
    }
}
