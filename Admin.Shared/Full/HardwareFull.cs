
using Admin.Shared.Base;

namespace Admin.Shared.Full;

public class HardwareFull : HardwareBase
{
    public SnmpBase? Snmp { get; set; }
    public TelnetBase? Telnet { get; set; }
}
