namespace Admin.Shared.Response;

public class TelnetResponse
{
    public int Id { get; set; }
    public string User { get; set; }
    public string Password { get; set; }
    public int Port { get; set; }
    public int HardwareId { get; set; }
}