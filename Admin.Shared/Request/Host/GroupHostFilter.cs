namespace Admin.Shared.Request.Host;

public class GroupHostFilter
{
    public string Name { get; set; } = String.Empty;
    public List<int>? Ids { get; set; }
}