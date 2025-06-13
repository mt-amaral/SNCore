namespace Admin.Shared.Request.Account;

public class ChangePasswordRequest
{
    public string UserName { get; set; } = string.Empty;
    public string CurrentPassword { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public string NewPassword { get; set; } = string.Empty;
}