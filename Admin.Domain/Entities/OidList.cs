
using Admin.Domain.Entities.Base;

namespace Admin.Domain.Entities;

public class OidList : BaseLongEntity
{
    public string Description { get; set; }
    public Item Item { get; set; }
    
}
