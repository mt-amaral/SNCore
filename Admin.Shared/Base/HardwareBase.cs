using Admin.Shared.Enums;
namespace Admin.Shared.Base;

public class HardwareBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Model HardwareModel { get; set; }
    public string Ipv4 { get; set; }
}
