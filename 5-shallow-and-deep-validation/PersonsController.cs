using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Sample
{
    [Route("api/persons")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IMediator mediator;

        public PersonsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<ActionResult<User>> Create(SignUp request)
        {
            var person = await mediator.Send(request);

            return person;
        }

        [HttpPost("update")]
        public async Task<ActionResult<User>> Update(UpdatePerson request)
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
