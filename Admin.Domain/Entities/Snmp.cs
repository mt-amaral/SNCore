

using Admin.Domain.Entities.Base;

namespace Admin.Domain.Entities;

public enum SNMPVersion : short
{
    v1 = 0,
    v2 = 1,
    v3 = 2
}
public class Snmp : BaseEntity
{
    public SNMPVersion SnmpVersion { get; private set; }
    public string Community { get; private set; }
    public int Port { get; private set; }
    public int HostId { get; private set; }
    public Host Host { get; set; }

    public void SetHostId(int hostId)
    {
        HostId = hostId;
    }
}
