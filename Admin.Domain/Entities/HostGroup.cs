
using Admin.Domain.Entities.Base;

namespace Admin.Domain.Entities;


public class HostGroup : BaseEntity
{
    public string GroupName { get; set; }
    public ICollection<Host> Hosts { get; set; } = new HashSet<Host>();

}
