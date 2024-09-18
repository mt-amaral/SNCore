
using Admin.Domain.Entities.Base;

namespace Admin.Domain.Entities;

public class Host : BaseEntity
{
    public string Description { get; private set; }
    public string Name { get; private set; }
    public bool IsOnline { get; private set; }
    public string Ipv4 { get; private set; }
    public Snmp? Snmp { get; set; }
    public Telnet? Telnet { get; set; }
    public int? GroupId { get; private set; }
    public HostGroup? HostGroup { get; set; }
    public int? ModelId { get; private set; }
    public HostModel? HostModel { get; set; }
}
