﻿
namespace Admin.Domain.Entities;

public class Host
{
    public int Id { get; init; }
    public string Description { get; private set; } = string.Empty;
    public string Name { get; private set; } = string.Empty;
    public bool IsOnline { get; private set; } = false;
    public string Ipv4 { get; private set; } = "0.0.0.0";
    public int? GroupId { get; private set; }
    public int? ModelId { get; private set; }
    public Telnet? Telnet { get; private set; }
    public HostGroup? HostGroup { get; private set; }
    public Snmp? Snmp { get; private set; }
    public HostModel? HostModel { get; private set; }

    public ICollection<Item> Items { get; private set; } = new HashSet<Item>();
    public ICollection<RunTime> RunTimes { get; private set; } = new HashSet<RunTime>();


    public void UpdateGruopId(int? id) => GroupId = id;

}
