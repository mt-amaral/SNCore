﻿
using Admin.Domain.Entities.Base;

namespace Admin.Domain.Entities;
public enum HardwareModel : short
{
    model1 = 0,
    model2 = 1,
    model3 = 3
}

public class Hardware : BaseEntity
{
    public string Description { get; private set; }
    public string Name { get; private set; }
    public bool IsOnline { get; private set; }
    public HardwareModel Model { get; private set; }
    public string Ipv4 { get; private set; }
    public Snmp Snmp { get; set; }
    public Telnet Telnet { get; set; }

}
