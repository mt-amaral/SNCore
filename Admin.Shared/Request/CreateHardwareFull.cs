using Admin.Shared.Payload;

namespace Admin.Shared.Request;

public class CreateHardwareFull: HardwarePayload
{
    public SnmpPayload? Snmp { get; set; }
    public TelnetPayload? Telnet { get; set; }

}
