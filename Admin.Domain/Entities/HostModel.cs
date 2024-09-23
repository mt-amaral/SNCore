
using Admin.Domain.Entities.Base;

namespace Admin.Domain.Entities;


public class HostModel : BaseEntity
{
    public string ModelName { get; set; }
    public ICollection<Host> Hosts { get; set; } = new HashSet<Host>();
    public ICollection<Item> Items { get; set; } = new HashSet<Item>();


}
