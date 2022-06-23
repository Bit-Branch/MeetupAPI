using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MeetupAPI.Domain.Constants;
using MeetupAPI.Application.Commands.Meetups;
using MeetupAPI.Application.Queries.Meetups;

namespace MeetupAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = Roles.Admin)]
    public class MeetupsController : ApiControllerBase
    {
        public MeetupsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreateMeetup(CreateMeetupCommand command)
        {
            var meetupId = await CommandAsync(command);

            return Ok(meetupId);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMeetup(UpdateMeetupCommand command)
        {
            var meetup = await CommandAsync(command);

            return meetup == null ? NoContent() : Ok(meetup);
        }

        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetMeetup(int id)
        {
            var meetup = await QueryAsync(new GetMeetupQuery { MeetupId = id });

            if (meetup == null)
            {
                return NotFound();
            }

            return Ok(meetup);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllMeetups()
        {
            var meetups = await QueryAsync(new GetAllMeetupsQuery());

            return Ok(meetups);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMeetup(int id)
        {
            var deletedMeetupId = await CommandAsync(new DeleteMeetupCommand { MeetupId = id });

            if (deletedMeetupId == -1)
            {
                return NoContent();
            }

            return Ok(deletedMeetupId);
        }
    }
}
