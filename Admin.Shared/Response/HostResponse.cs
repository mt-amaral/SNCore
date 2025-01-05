namespace Admin.Shared.Response;

public class HostResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Ipv4 { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
}