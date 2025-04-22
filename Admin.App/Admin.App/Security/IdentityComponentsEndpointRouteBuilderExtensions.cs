using System.Security.Claims;
using System.Text.Json;
using Admin.Domain.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace Admin.App.Security
{
    internal static class IdentityComponentsEndpointRouteBuilderExtensions
    {
        // These endpoints are required by the Identity Razor components defined in the /Components/Account/Pages directory of this project.
        public static IEndpointConventionBuilder MapAdditionalIdentityEndpoints(this IEndpointRouteBuilder endpoints)
        {
            ArgumentNullException.ThrowIfNull(endpoints);

            var accountGroup = endpoints.MapGroup("");

            //accountGroup.MapPost("/Logout", async (
            //    ClaimsPrincipal user,
            //    [FromServices] SignInManager<User> signInManager,
            //    [FromForm] string returnUrl) =>
            //{
            //    await signInManager.SignOutAsync();
            //    return TypedResults.LocalRedirect($"~/{returnUrl}");
            //});
            

            return accountGroup;
        }
    }
}
