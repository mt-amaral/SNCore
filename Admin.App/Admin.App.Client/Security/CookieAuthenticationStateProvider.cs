using System.Net.Http.Json;
using System.Security.Claims;
using Admin.Shared.Response.User;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace Admin.App.Client.Security;
public class CookieAuthenticationStateProvider : AuthenticationStateProvider, ICookieAuthenticationStateProvider
{
    private readonly HttpClient _httpClient;
    private readonly NavigationManager _navigationManager;
    private readonly ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

    public CookieAuthenticationStateProvider(IHttpClientFactory factory, NavigationManager navigationManager)
    {
        _httpClient =  factory.CreateClient("Api");

        _navigationManager = navigationManager;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            // Chama o endpoint para obter os dados do usuário autenticado.
            var userInfo = await _httpClient.GetFromJsonAsync<UserResponse>("/auth-state");

            if (userInfo is not null && !string.IsNullOrEmpty(userInfo.Username))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userInfo.Username)
                    // Adicione outros claims se necessário
                };

                var identity = new ClaimsIdentity(claims, "serverAuth");
                var user = new ClaimsPrincipal(identity);
                return new AuthenticationState(user);
            }
        }
        catch
        {
            // Se houver erro, retorna usuário anônimo
        }

        return new AuthenticationState(_anonymous);
    }

    public async Task MarkUserAsAuthenticated(string username)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username)
        };

        var identity = new ClaimsIdentity(claims, "serverAuth");
        var user = new ClaimsPrincipal(identity);

        // Notifica a mudança no estado de autenticação.
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
    }

    public async Task MarkUserAsLoggedOut()
    {
        // Notifica a mudança para usuário anônimo.
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_anonymous)));

        // Opcional: redireciona para a página de login
        _navigationManager.NavigateTo("/");
    }

    public async Task RefreshAuthenticationState()
    {
        // Força a atualização do estado de autenticação
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}
