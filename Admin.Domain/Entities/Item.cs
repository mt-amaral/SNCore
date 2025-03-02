
using Admin.Domain.Entities.Base;

namespace Admin.Domain.Entities;

public class Item : BaseEntity
{
    public string ItemName { get; private set; } = string.Empty;
    public int? ModelId { get; private set; }
    public long? OidId { get; private set; }

    public OidList? OidList { get; private set; }
    public HostModel? HostModel { get; private set; }
    public ICollection<CronExpression> CronExpression { get; private set; } = new List<CronExpression>();
}
