using System.ComponentModel.DataAnnotations;
using Admin.Shared.Request.Host;
using Microsoft.Extensions.Logging;

namespace Admin.Shared.Request.Schedule;

public enum TypeRun : byte
{
    Snmp = 0,
    Telnet = 1,
}
public class CreateScheduleRequest
{
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public short ExpressionId { get; set; }
    [Required]
    public long ItemId { get; set; }
    [Required]
    public int? HostId { get; set; }
    [Required]
    public int? ModelId { get; set; }
    [Required]
    public bool Active { get; set; } = false;
    public TypeRun Type { get; set; } = TypeRun.Snmp;
}

