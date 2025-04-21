using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Admin.App.Filter;

public class ValidateIdFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ActionArguments.TryGetValue("id", out var value))
        {
            if (value is short shortId && shortId <= 0 ||
                value is int intId && intId <= 0 ||
                value is long longId && longId <= 0)
            {
                context.Result = new BadRequestObjectResult(new
                {
                    Message = "O Id deve ser um número inteiro positivo maior que zero.",
                    ProvidedValue = value
                });
                return;
            }
        }
        else
        {
            context.Result = new BadRequestObjectResult(new
            {
                Message = "Id ausente ou inválido.",
                ProvidedValue = value
            });
            return;
        }

        base.OnActionExecuting(context);
    }
}
