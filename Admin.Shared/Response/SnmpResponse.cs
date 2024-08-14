

namespace Admin.Shared.Response;

public class SnmpResponse
{
    public string Version { get; set; }
    public string Community { get; set; }
    public int Port { get; set; }
    public int HardwareId { get; set; }
}