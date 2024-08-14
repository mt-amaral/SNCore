namespace Admin.Shared.Request;

public class TelnetRequest
{
    public int Id { get; set; }
    public string User { get; set; }
    public string Password { get; set; }
    public int Port { get; set; }
    public int HardwareId { get; set; }
}