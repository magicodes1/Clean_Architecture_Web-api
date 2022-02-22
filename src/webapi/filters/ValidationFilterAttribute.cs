using Delicious.core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Delicious.webapi
{
    public class ValidationFilterAttribute : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var id = context.ActionArguments.SingleOrDefault(p=>p.Key=="id");
            var entity = context.ActionArguments.SingleOrDefault(p=>p.Value is DTO);

            if(id.Value!=null && entity.Value!=null){
                var obj = entity.Value as DTO;

                if(obj!.id != (int)id.Value) {
                    context.Result = new BadRequestObjectResult("Your id did not match");
                    return;
                }
            }

            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
                return;
            }
            await next();
        }
    }
}