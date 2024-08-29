
using Admin.Shared.Base;
using Admin.Shared.Request;

namespace Admin.Shared.Full;

public class HardwareFull : HardwareBase
{
    public int Id { get; set; }
    public SnmpBase? Snmp { get; set; }
    public TelnetBase? Telnet { get; set; }
}
