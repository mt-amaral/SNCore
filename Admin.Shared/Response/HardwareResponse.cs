

using Admin.Shared.Payload;

namespace Admin.Shared.Response;

public class HardwareResponse : HardwarePayload
{
    public int Id { get; set; }
    public bool IsOnline { get; set; }
    public SnmpPayload? Snmp { get; set; }
    public TelnetPayload? Telnet { get; set; }

}