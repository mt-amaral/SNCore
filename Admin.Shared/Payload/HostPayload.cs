namespace Admin.Shared.Payload;

public enum HostModel : short
{
    model1 = 0,
    model2 = 1,
    model3 = 3
}
public class HostPayload
{
    public string Name { get; set; }
    public string Description { get; set; }
    public HostModel Model { get; set; }
    public string Ipv4 { get; set; }
}
