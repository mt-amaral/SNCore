using Admin.Domain.Entities.Base;

namespace Admin.Domain.Entities;

public class OidDiscovery : BaseLongEntity
{
    
    public String OidDiscoveryIndex { get; set; } 
    public long? DiscoveryOriginId { get; set; }
    public OidList? DiscoveryOrigin { get; set; }
    
}