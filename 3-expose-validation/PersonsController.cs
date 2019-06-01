using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Sample
{
    [Route("api/[controller]")]
    [ApiController] /** <= ASP.NET Core built-in feature that will validate each incoming request **/
    public class PersonsController : Controller
    {
        private readonly DataContext ctx;

        public PersonsController(DataContext ctx)
        {
            this.ctx = ctx;
        }

        [Validatable]
        [HttpPost("create")]
        public async Task<IActionResult> CreatePerson(CreatePerson request)
        {
            var person = request.ToPerson();

            ctx.Persons.Add(person);
            await ctx.SaveChangesAsync();

            return Ok(person.Id);
        }
    }
}
