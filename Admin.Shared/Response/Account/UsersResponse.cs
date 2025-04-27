using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.Shared.Response.Account;

public class UsersResponse
{
    public string Id { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;
    
    public string Email { get; set; } = string.Empty;
}