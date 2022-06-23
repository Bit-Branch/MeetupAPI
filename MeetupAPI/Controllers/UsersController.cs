using MediatR;
using Microsoft.AspNetCore.Mvc;
using MeetupAPI.Application.Commands.Users;

namespace MeetupAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ApiControllerBase
    {
        public UsersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateUserCommand authenticateUserCommand)
        {
            var authenticationResponse = await CommandAsync(authenticateUserCommand);

            if (authenticationResponse == null)
            {
                return Unauthorized("Login or password invalid.");
            }

            return Ok(authenticationResponse);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            await CommandAsync(command);

            return Ok("Registration successful.");
        }
    }
}
