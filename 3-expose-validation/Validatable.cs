using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System.Linq;

namespace Sample
{
    public class ValidatableAttribute : ActionFilterAttribute
    {
        private const string HeaderName = "x-action-intent";

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            StringValues header = context.HttpContext.Request.Headers[HeaderName];
            string intent = header.FirstOrDefault();
            if (intent == null)
            {
                // If there is no header set we will short-circuit the request pipeline by setting context.Result with a BadRequest.
                context.Result = new BadRequestObjectResult($"Missing header '{HeaderName}'");
                return;
            }

            if (!context.ModelState.IsValid)
            {
                // If the parameters that were send are not valid we will also in all cases short-circuit the pipeline.
                context.Result = new BadRequestObjectResult(context.ModelState);
                return;
            }

            switch (intent)
            {
                case "validate":
                {
                    // If the clients intent is 'validate' we will short-circuit the request pipeline and return HTTP OK.
                    context.Result = new NoContentResult(); break;
                }
                case "execute":
                {
                    // If the clients intent is 'execute' we will not do anything here.
                    // Default request pipeline continues and eventually our controller method is invoked.
                    break;
                }
                default:
                {
                    context.Result = new BadRequestObjectResult($"Unknown _action parameter value: '{HeaderName}'");
                    break;
                }
            }

        }
    }
}
