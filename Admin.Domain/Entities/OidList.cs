
namespace Admin.Domain.Entities;

public class OidList
{
    public long Id { get; init; }
    public string Oid { get; private set; } = string.Empty;
    public Item Item { get; private set; } = (null!);
    
}
