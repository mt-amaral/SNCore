namespace Admin.App.Client.Security;

public interface ICookieAuthenticationStateProvider
{
    /// <summary>
    /// Marca o usuário como autenticado e atualiza o estado.
    /// </summary>
    /// <param name="username">Nome do usuário autenticado.</param>
    Task MarkUserAsAuthenticated(string username);

    /// <summary>
    /// Marca o usuário como deslogado e atualiza o estado.
    /// </summary>
    Task MarkUserAsLoggedOut();

    /// <summary>
    /// Força a atualização do estado de autenticação.
    /// </summary>
    Task RefreshAuthenticationState();
}