
using Admin.Domain.Entities.Base;

namespace Admin.Domain.Entities;

public class Telnet : BaseEntity
{
    public string User { get; private set; }
    public string Password { get; private set; }
    public int Port { get; private set; }

    public int HostId { get; private set; }
    public Host Host { get; set; }

    public void SetHostId(int hostId)
    {
        HostId = hostId;
    }
};
