using Admin.Application.Interfaces;
using Admin.Shared.Request.Expression;
using Admin.Shared.Response.Expression;
using Microsoft.AspNetCore.Mvc;
using Admin.Api.Filter;
using Admin.Shared.Request.User;
using Admin.Shared.Response;
using Admin.Shared.Response.User;

namespace Admin.Api.Controllers.v1;

public class UserController : BaseController
{

    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
}
