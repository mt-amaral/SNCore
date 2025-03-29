using Admin.Shared.Request.User;
using Admin.Shared.Response;
using Admin.Shared.Response.User;

namespace Admin.Application.Interfaces;

public interface IUserService
{
    Task<Response<UserResponse?>> Create(NewUserRequest user);
    Task<Response<LoginToken?>> Login(LoginRequest login);
    //Task<bool> UserExists(string username, string password);
    //public string GenerateToken(int id, string);

}