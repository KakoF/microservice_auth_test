using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace apiAuth.Middleware
{
    public class ValidationMiddleware : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var jsonModelValidate = context.ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage).ToList();
                context.Result = new BadRequestObjectResult(new { error = jsonModelValidate });
                return;
            }
            await next();
        }
    }
}
