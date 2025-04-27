using Admin.Application.Interfaces;
using Admin.Domain.Account;
using Admin.Domain.Interfaces;
using Admin.Shared.Request.Account;
using Admin.Shared.Response;
using Admin.Shared.Response.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Admin.App.Controllers.v1;


public class AccountController : BaseController
{

    private readonly IUserService _userService;
    
    public AccountController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userRequest"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginRequest userRequest)
    {
        var result = await _userService.Login(userRequest);
        return result.IsSuccess ? Ok() : Unauthorized();
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(Response<string?>), StatusCodes.Status200OK)]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var result = await _userService.Register(request);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(Response<List<UsersResponse?>>), StatusCodes.Status200OK)]
    [Route("ListUsers")]
    public async Task<IActionResult> ListUsers()
    {
        var users = await _userService.GetUsers();   
        return Ok(users);
        
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Route("logout")]
    public async Task<IActionResult> Logout()
    {
        await _userService.Logout();
        return Ok();
    }
}