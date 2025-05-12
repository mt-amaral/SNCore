

namespace Admin.Shared.Response.Host;

public class GroupHostResponse
{
    public int Id { get; set; }
    public string GroupName { get; set; } = string.Empty;
    public int? CountHost { get; set; }
}
