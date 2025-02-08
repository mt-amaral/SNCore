namespace Admin.Shared.Response;

public class SysInfoResponse
{
    public string Version { get; set; } = string.Empty;
    
    public string Uptime { get; set; } = string.Empty;
    public string Cpu { get; set; } = string.Empty;
    public string Ram { get; set; } = string.Empty;
    public string Storage { get; set; } = string.Empty;
    public string Scheduler { get; set; } = string.Empty;
    public string Backup { get; set; } = string.Empty;
}