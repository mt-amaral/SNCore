

namespace Admin.Shared.Response;

public class ExpressionResponse
{
    public long Id { get; set; }
    public string Expression { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool Active { get; set; } = true;
    public int ItemId { get; set; }
    public string ItemName { get; set; } = string.Empty;
    public int HostId { get; set; }
    public string HostName { get; set; } = string.Empty;

}