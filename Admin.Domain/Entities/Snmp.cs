using Admin.Domain.Validations;
using FluentValidation;

namespace Admin.Domain.Entities
{
    public class Snmp : BaseEntity
    {
        public string Version { get; private set; }
        public string Community { get; private set; }
        public int Port { get; private set; }
        public int HardwareId { get; set; }
        public Hardware Hardware { get; set; }

        private readonly IValidator<Snmp> _validator;

        public Snmp(int id, string version, string community, int port)
        {
            _validator = new SnmpValidation();
            Id = id;
            Version = version;
            Community = community;
            Port = port;

            _validator.ValidateAndThrow(this);
        }

        public void Update(string version, string community, int port)
        {
            Version = version;
            Community = community;
            Port = port;

            UpDate();
            _validator.ValidateAndThrow(this);
        }
    }
}
