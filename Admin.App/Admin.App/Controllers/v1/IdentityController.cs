using Admin.Domain.Account;
using Admin.Shared.Request.Account;
using Admin.Shared.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Admin.App.Controllers.v1;


public class IdentityController : BaseController
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;


    public IdentityController(SignInManager<User> signInManager, UserManager<User> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
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
        var user = await _userManager.FindByEmailAsync(userRequest.Username);
        if (user == null) return Unauthorized();

        var result = await _signInManager.PasswordSignInAsync(userRequest.Username, userRequest.Password, true, false);
        return result.Succeeded ? Ok() : Unauthorized();
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
        var user = new User { UserName = request.UserName, Email = request.UserEmail};

        var result = await _userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
            return Ok(new Response<string?>(null, 200, $"User {request.UserName} registered successfully"));

        return BadRequest(result.Errors);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Route("logout")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return Ok();
    }
}