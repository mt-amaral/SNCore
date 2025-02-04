namespace Admin.App.Client.Data;

public class LoginModel
{
    public string Email { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;
    public bool RememberMe { get; set; }
}