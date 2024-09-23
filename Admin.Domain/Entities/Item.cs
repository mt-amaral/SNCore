

using Admin.Domain.Entities.Base;

namespace Admin.Domain.Entities;

public class Item : BaseEntity
{
    public string ItemName { get; set; }
    public int? ModelId { get; private set; }
    public HostModel? HostModel { get; set; }
}
