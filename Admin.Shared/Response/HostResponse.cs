

using Admin.Shared.Payload;

namespace Admin.Shared.Response;

public class HostResponse : HostPayload
{
    public int Id { get; set; }
    public bool IsOnline { get; set; }
    public string? GroupName { get; set; }
    public SnmpPayload? Snmp { get; set; }
    public TelnetPayload? Telnet { get; set; }

}