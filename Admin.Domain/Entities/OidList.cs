
using Admin.Domain.Entities.Base;

namespace Admin.Domain.Entities;

public class OidList : BaseLongEntity
{
    public string Oid { get; set; }
    public Item Item { get; set; }
    public OidDiscovery? OidDiscovery { get; set; }
    
}
