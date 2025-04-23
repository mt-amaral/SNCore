namespace Admin.Domain.Entities;

public enum TypeRun : byte
{
    Snmp = 0,
    Telnet = 1,
}

public class RunTime
{
    public long Id { get; init; }
    public TypeRun Type { get; private set; } = TypeRun.Snmp;
    public bool Active { get; private set; } = false;
    public short CronExpressionId { get; private set; }
    public long ItemId { get; private set; }
    public int? HostId { get; private set; }
    public int? ModelId { get; private set; }

    public CronExpression CronExpression { get; private set; } = new();
    public Item Item { get; private set; } = new();
    public Host Host { get; private set; } = new();
    public HostModel HostModel { get; private set; } = new();
}