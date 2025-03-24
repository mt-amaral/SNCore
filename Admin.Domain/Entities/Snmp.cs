


namespace Admin.Domain.Entities;

public enum SnmpVersion : byte
{
    V1 = 0,
    V2 = 1,
    V3 = 2
}
public class Snmp
{
    public int Id { get; init; }
    public SnmpVersion SnmpVersion { get; private set; } = SnmpVersion.V2;
    public string Community { get; private set; } = "public";
    public int Port { get; private set; } = 161;
    public int HostId { get; private set; }
    public Host Host { get; private set; } = (null!);


    public void SetHostId(int hostId)
    {
        HostId = hostId;
    }
}
