using Admin.Shared.Request.Account;
using Admin.Shared.Response;
using Admin.Shared.Response.Account;

namespace Admin.Application.Interfaces;

public interface IUserService
{
    Task<Response<List<UsersResponse?>>> GetUsers();
    Task<Response<string?>> Login(LoginRequest request, bool rememberMe = false);
    Task<Response<string?>> Register(RegisterRequest request);
    Task Logout();
}
