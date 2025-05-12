using Admin.Shared.Global;

namespace Admin.Shared.Response.Host;

public class HostResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Ipv4 { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public SnmpResponse? Snmp { get; set; }
    public TelnetResponse? Telnet { get; set; }
    public GroupHostResponse? GroupHost { get; set; }
}

public class SnmpResponse
{
    public SnmpVersionEnum SnmpVersion { get;  set; } = SnmpVersionEnum.V2;
    public string Community { get; set; } = string.Empty;
    public int Port { get; private set; } = 161;
}

public class TelnetResponse
{
    public string User { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int Port { get;  set; }
}