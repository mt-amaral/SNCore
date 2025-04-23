

namespace Admin.Domain.Entities;

public class Item
{
    public long Id { get; init; }
    public string ItemName { get; private set; } = string.Empty;
    public long? OidId { get; private set; }

    public int? HostId { get; private set; }
    public int? ModelId { get; private set; }
    public OidList? OidList { get; private set; }
    public HostModel? HostModel { get; private set; }
    public Host? Host { get; private set; }
    public ICollection<RunTime> RunTimes { get; private set; } = new HashSet<RunTime>();
}
