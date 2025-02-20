

namespace Admin.Domain.Entities;

public class CronExpression
{
    public long Id { get; init; }

    public string Minute { get; set; } = "*";
    public string Hour { get; set; } = "*";
    public string Day { get; set; } = "*";
    public string Month { get; set; } = "*";
    public string Weesday { get; set; } = "*";
    public string Expression { get; set; } = string.Empty;
    public int ItemId { get; set; }
    public int? HostId { get; set; } = null;

    public Item Item { get; set; } = null!;
    public Host? Host { get; set; } = null;

}
