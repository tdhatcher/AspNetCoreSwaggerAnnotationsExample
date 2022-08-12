using Microsoft.AspNetCore.Mvc.Filters;

namespace SwaggerAnnotationsExample.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Before

            //var result = _validator.Validate(stockDto);
            //ValidationProblemDetails problemDetails = new ValidationProblemDetails(result.ToDictionary());
            //return new BadRequestObjectResult(problemDetails);

            await next();

            // After
        }
    }
}
