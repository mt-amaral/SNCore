

namespace Admin.Domain.Entities;


public class HostModel
{
    public int Id { get; init; }
    public string ModelName { get; private set; } = string.Empty;
    public ICollection<Host> Hosts { get; private set; } = new HashSet<Host>();
    public ICollection<Item> Items { get; private set; } = new HashSet<Item>();
    public ICollection<RunTime> RunTimes { get; private set; } = new HashSet<RunTime>();
    public string? SrcIcon { get; private set; }
}
