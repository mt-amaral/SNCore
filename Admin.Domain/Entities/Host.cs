
using Admin.Domain.Entities.Base;

namespace Admin.Domain.Entities;

public class Host : BaseEntity
{
    public string Description { get; private set; } = string.Empty;
    public string Name { get; private set; } = string.Empty;
    public bool IsOnline { get; private set; } = false;
    public string Ipv4 { get; private set; } = "0.0.0.0";

    public int? GroupId { get; private set; }
    public int? ModelId { get; private set; }

    public Telnet? Telnet { get; private set; }
    public HostGroup? HostGroup { get; private set; }
    public Snmp? Snmp { get; private set; }
    public HostModel? HostModel { get; private set; }
    public ICollection<CronExpression>? CronExpression { get; private set; }
}
