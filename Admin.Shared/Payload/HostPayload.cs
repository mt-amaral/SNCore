namespace Admin.Shared.Payload;

public class HostPayload
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Ipv4 { get; set; }
    public int? ModelId { get; set; } = null;
    public int? GroupId { get; set; } = null;
}
