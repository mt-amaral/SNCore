


namespace Admin.Domain.Entities;

public class Telnet
{
    public int Id { get; init; }
    public string User { get; private set; } = string.Empty!;
    public string Password { get; private set; } = string.Empty;
    public int Port { get; private set; } = 23;
    public int HostId { get; private set; }
    public Host Host { get; private set; } = (null!);

    public void SetHostId(int hostId)
    {
        HostId = hostId;
    }
};
