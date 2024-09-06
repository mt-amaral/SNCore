namespace Admin.Shared.Payload;

public enum HardwareModel : short
{
    model1 = 0,
    model2 = 1,
    model3 = 3
}
public class HardwarePayload
{
    public string Name { get; set; }
    public string Description { get; set; }
    public HardwareModel Model { get; set; }
    public string Ipv4 { get; set; }
}
