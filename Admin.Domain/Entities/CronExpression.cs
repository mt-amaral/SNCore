

namespace Admin.Domain.Entities;

public class CronExpression
{
    public long Id { get; init; }
    public string Second { get; init; } = string.Empty;
    public string Minute { get; private set; } = string.Empty;
    public string Hour { get; private set; } = string.Empty;
    public string Day { get; private set; } = string.Empty;
    public string Month { get; private  set; } = string.Empty;
    public string Weesday { get; private set; } = string.Empty;
    
    public string Description { get; private set; } = string.Empty;
    public int ItemId { get; private set; }
    public int? HostId { get; private set; } = null;

    public Item Item { get;  private set; } = null!;
    public Host? Host { get; private set; } = null;


    public  void UpdateDescription(string description)
    {
         Description = description;
    }

}


