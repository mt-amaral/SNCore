using System.Net.Http.Json;
using Admin.Shared.Interfaces;
using Admin.Shared.Request.Account;
using Admin.Shared.Request.Expression;
using Admin.Shared.Response;
using Admin.Shared.Response.Account;
using System.Collections.Generic;


namespace Admin.App.Client.Service;

public class UserService : IUserService
{
    private readonly HttpClient _httpClient;
    public UserService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("Api");
    }

    /*public async Task<string> TranslationExpression(ExpressionRequest expression)
    {
        var response = await _httpClient.PutAsJsonAsync("Expression/Translation", expression);
        return await Task.FromResult("");
    }

    public async Task<Response<IEnumerable<GetExpressionResponse?>>> GetExpressions()
    { 
        return await _httpClient.GetFromJsonAsync<Response<IEnumerable<GetExpressionResponse?>>>("Expression/GetAll");
            
    }

    public async Task<Response<ExpressionResponse>> GetExpression(short id)
    {
        return await Task.FromResult(new Response<ExpressionResponse>());
    }

    public async  Task<Response<ExpressionResponse?>> CreateExpression(ExpressionRequest expression)
    {
        return await Task.FromResult(new Response<ExpressionResponse?>());
    }

    public async  Task<Response<string?>> UpdateExpression(ExpressionRequest expression, short id)
    {
        return await Task.FromResult(new Response<string?>());
    }

    public async  Task<Response<string?>> DeleteExpression(short id)
    {
        return await Task.FromResult(new Response<string?>());
    }*/

    public  Task<Response<List<UsersResponse?>>> GetUsers()
    {
        return  _httpClient.GetFromJsonAsync<Response<List<UsersResponse?>>>("Account/getUsers")!;
    }

    public Task<Response<string?>> Login(LoginRequest request, bool rememberMe = false)
    {
        throw new NotImplementedException();
    }

    public Task<Response<string?>> Register(RegisterRequest request)
    {
        throw new NotImplementedException();
    }

    public Task Logout()
    {
        throw new NotImplementedException();
    }

    public Task<Response<string?>> ChangePasswordNew(ChangePasswordRequest request)
    {
        throw new NotImplementedException();
    }
}