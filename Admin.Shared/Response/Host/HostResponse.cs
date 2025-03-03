namespace Admin.Shared.Response.Host;

public class HostResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Ipv4 { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}