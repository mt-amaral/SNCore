using Admin.Application.Interfaces;
using Admin.Domain.Account;
using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Shared.Request.Account;
using Admin.Shared.Request.Expression;
using Admin.Shared.Response;
using Admin.Shared.Response.Account;
using Admin.Shared.Response.Expression;
using AutoMapper;
using CronExpressionDescriptor;
using Microsoft.AspNetCore.Identity;

namespace Admin.Application.Services;

public class UserService : IUserService
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;
    
    public UserService(IUserRepository repository, SignInManager<User> signInManager, UserManager<User> userManager,
        IMapper mapper)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response<List<UsersResponse?>>> GetUsers()
    {
        return new Response<List<UsersResponse?>>(_mapper.Map<List<UsersResponse?>>(await _repository.GetAll())
            , 200, null);
    }


    public async Task<Response<string?>> Login(LoginRequest request, bool rememberMe = false)
    {
        var user = await _userManager.FindByEmailAsync(request.UserEmail);
        if (user == null)
            return new Response<string?>(null, 401, "Credencias invalidas");
        
        var result = await _signInManager.PasswordSignInAsync(user.UserName!, request.Password, rememberMe, false);
        if (!result.Succeeded)
            return new Response<string?>(null, 401, "Credencias invalidas");
        return new Response<string?>(null, 200, $"{user.UserName} Logado com sucesso!");
    }

    public async Task<Response<string?>> Register(RegisterRequest request)
    {
        var user = new User { UserName = request.UserName, Email = request.UserEmail};
        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
            return new Response<string?>(null, 400, $" Erro: {result.Errors}");
            
        return new Response<string?>(null, 200, $"Usuario {request.UserName} registrado com sucesso!");
    }
    
    
    public Task Logout() => _signInManager.SignOutAsync();

}
