namespace Admin.Shared.Response.User;

public class LoginToken
{
    public Guid Id { get; set; }
    public string Token { get; set; } = string.Empty;
}