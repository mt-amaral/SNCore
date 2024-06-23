using System.Runtime.Serialization;

namespace Admin.App.Model;

public class HardwareModel
{
    public int Id { get; set; } 
    public string Description { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string Ipv4 { get; set; } = string.Empty;
}
