
namespace Admin.Domain.Entities;

public class Telnet : BaseEntity
{
    public string User { get; private set; }
    public string Password { get; private set; }
    public int Port { get; private set; }

    public int HardwareId { get; set; }
    public Hardware Hardware { get; set; }

};
