using Admin.Domain.Account;
using Admin.Shared.Request.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Api.Controllers.v1;


public class IdentityController : ControllerBase
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;


    public IdentityController(SignInManager<User> signInManager, UserManager<User> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }
    
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginRequest model)
    {
        var user = await _userManager.FindByNameAsync(model.Username);
        if (user == null) return Unauthorized();

        var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);
        return result.Succeeded ? Ok() : Unauthorized();
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var user = new User { UserName = request.UserName };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
            return Ok("Usuário criado com sucesso.");

        return BadRequest(result.Errors);
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return Ok();
    }
}