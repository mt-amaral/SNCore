namespace Admin.Shared.Request;

public class SnmpRequest
{
    public int Id { get; set; }
    public string Version { get; set; }
    public string Community { get; set; }
    public int Port { get; set; }
    public int HardwareId { get; set; }
}