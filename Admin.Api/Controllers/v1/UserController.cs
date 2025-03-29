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
    
    
    [HttpPost]
    [ProducesResponseType(typeof(Response<UserResponse?>), StatusCodes.Status201Created)]
    public async Task<ActionResult> Create(NewUserRequest user)
    {
        var result = await _userService.Create(user);
        return StatusCode(result.IsSuccess ? 201 : 409, result);
    }
    
    [HttpPut]
    [ProducesResponseType(typeof(Response<LoginToken?>), StatusCodes.Status200OK)]
    public async Task<ActionResult> Login(LoginRequest login)
    {
        var result = await _userService.Login(login);
        return StatusCode(result.IsSuccess ? 200 : 409, result);
    }
    
}
