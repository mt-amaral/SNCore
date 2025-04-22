using Admin.Domain.Account;
using Admin.Shared.Request.Identity;
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
    [Route("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var user = new User { UserName = request.UserName };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
            return Ok("Usuário criado com sucesso.");

        return BadRequest(result.Errors);
    }
}