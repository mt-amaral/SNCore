

namespace Admin.Domain.Entities;

public class Snmp : BaseEntity
{
    public string Version { get; private set; }
    public string Community { get; private set; }
    public int Port { get; private set; }
    public int HardwareId { get; private set; }
    public Hardware Hardware { get; set; }
}
