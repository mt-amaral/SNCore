using Admin.Domain.Entities.Base;

namespace Admin.Domain.Entities;


public class HostGroup : BaseEntity
{
    public string GroupName { get; private set; } = string.Empty;
    public ICollection<Host> Hosts { get; private set; } = (null!);
}
