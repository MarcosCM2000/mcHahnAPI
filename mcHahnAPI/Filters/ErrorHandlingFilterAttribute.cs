using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace mcHahnAPI.Filters
{
    public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            context.Result = new ObjectResult(new { error = "An error ocurred while processing request." })
            {
                StatusCode = 500
            };
            context.ExceptionHandled = true;

        }
    }
}
