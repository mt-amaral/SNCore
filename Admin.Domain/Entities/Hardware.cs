using Admin.Domain.Enums;

namespace Admin.Domain.Entities
{
    public class Hardware : BaseEntity
    {
        public string Description { get; private set; }
        public string Name { get; private set; }
        public bool IsOnline { get; private set; }
        public Model HardwareModel { get; private set; }
        public string Ipv4 { get; private set; }
        public Snmp Snmp { get; set; }
        public Telnet Telnet { get; set; }

    }
}
