
using Admin.Domain.Entities.Base;

namespace Admin.Domain.Entities;


public class HostModel : BaseEntity
{
    public string ModelName { get; private set; } = string.Empty;
    public ICollection<Host> Hosts { get; private set; } = new HashSet<Host>();
    public ICollection<Item> Items { get; private set; } = new HashSet<Item>();
}
