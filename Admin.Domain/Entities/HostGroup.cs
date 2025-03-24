
namespace Admin.Domain.Entities;


public class HostGroup 
{
    public int Id { get; init; }
    public string GroupName { get; private set; } = string.Empty;
    public ICollection<Host> Hosts { get; private set; } = (null!);
}
