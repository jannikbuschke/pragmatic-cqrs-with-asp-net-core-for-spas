using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Sample
{
    [Route("api/Persons")]
    [ApiController]
    [ApiVersion("1.0")]
    public class PersonCommandsController : ControllerBase
    {
        private readonly IMediator mediator;

        public PersonCommandsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<ActionResult<Person>> Create(CreatePerson request)
        {
            var person = await mediator.Send(request);

            return person;
        }

        [HttpPost("update")]
        public async Task<ActionResult<Person>> Update(UpdatePerson request)
        {
            var person = await mediator.Send(request);

            return person;
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(DeletePerson request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
