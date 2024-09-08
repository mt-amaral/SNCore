
using Admin.Shared.Payload;

namespace Admin.Shared.Request;

public class HardwareRequest : HardwarePayload
{
    public SnmpPayload? Snmp { get; set; }
    public TelnetPayload? Telnet { get; set; }
}
