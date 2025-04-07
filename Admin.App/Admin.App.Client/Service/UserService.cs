using Admin.Shared.Request.Expression;
using Admin.Shared.Response.Expression;
using System.Net.Http.Json;
using Admin.App.Client.Security;
using Admin.Shared.Request.Identity;
using Admin.Shared.Response;

namespace Admin.App.Client.Service;

public class UserService(IHttpClientFactory factory)
{
    private readonly HttpClient _httpClient = factory.CreateClient("Api");
    
    
    public async Task<Response<string>> Login(LoginRequest loginRequest)
    {
        var response = await _httpClient.PostAsJsonAsync("/login", loginRequest);
        return response.IsSuccessStatusCode
            ? new Response<string>("Login realizado com sucesso!", 200, "Login realizado com sucesso!")
            : new Response<string>(null, 400, "Não foi possível realizar o login");
        response.EnsureSuccessStatusCode();
    }
    
    public async Task<Response<string?>> Logout()
    {
        var response = await _httpClient.PostAsJsonAsync<object>("/Logout", null);
        return response.IsSuccessStatusCode
            ? new Response<string?>(null, 200)
            : new Response<string?>(null, 400, "Erro ao carregar o logout");
        response.EnsureSuccessStatusCode();
    }
}