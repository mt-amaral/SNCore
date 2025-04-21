using Microsoft.AspNetCore.Mvc.Filters;

namespace Admin.App.Filter;

public class RequestDebugFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var user = context.HttpContext.User;
        Console.WriteLine($"[FILTER] Path: {context.HttpContext.Request.Path}");
        Console.WriteLine($"[FILTER] Authenticated: {user.Identity?.IsAuthenticated}");
        Console.WriteLine($"[FILTER] Claims: {string.Join(", ", user.Claims.Select(c => $"{c.Type}={c.Value}"))}");
    }

    public void OnActionExecuted(ActionExecutedContext context) { }
}