
using Admin.Domain.Entities.Base;

namespace Admin.Domain.Entities;

public class Telnet : BaseEntity
{
    public string User { get; private set; }
    public string Password { get; private set; }
    public int Port { get; private set; }

    public int HardwareId { get; private set; }
    public Hardware Hardware { get; set; }

    public void SetHardwareId(int hardwareId)
    {
        HardwareId = hardwareId;
    }
};
