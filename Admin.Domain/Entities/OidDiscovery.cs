namespace Admin.Domain.Entities;

public class OidDiscovery
{
    public long Id { get; init; }
    public string OidDiscoveryIndex { get; private set; } = string.Empty;
    public long? DiscoveryOriginId { get; private set; }
    public OidList? DiscoveryOrigin { get; private set; }
}