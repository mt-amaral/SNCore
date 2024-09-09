
using Admin.Shared.Payload;

namespace Admin.Shared.Request;

public class HostRequest : HostPayload
{
    public SnmpPayload? Snmp { get; set; }
    public TelnetPayload? Telnet { get; set; }
}
