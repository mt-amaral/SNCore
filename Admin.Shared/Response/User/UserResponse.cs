

namespace Admin.Shared.Response.User;

public class UserResponse
{
    public Guid Unique { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;
    
}