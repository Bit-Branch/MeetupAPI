using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventsManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ApiControllerBase : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApiControllerBase(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
        }

        protected async Task<TResult> CommandAsync<TResult>(IRequest<TResult> command)
        {
            return await _mediator.Send(command);
        }

        protected async Task<TResult> QueryAsync<TResult>(IRequest<TResult> query)
        {
            return await _mediator.Send(query);
        }
    }
}
