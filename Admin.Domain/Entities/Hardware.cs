using Admin.Domain.Validations;
using FluentValidation;

namespace Admin.Domain.Entities
{
    public class Hardware : BaseEntity
    {
        public string Description { get; private set; }
        public string Name { get; private set; }
        public bool IsOnline { get; private set; }
        public string Model { get; private set; }
        public string Ipv4 { get; private set; }

        public Snmp Snmp { get; set; }
        public Telnet Telnet { get; set; }

        private readonly IValidator<Hardware> _validator;

        public Hardware(int id, string name, string description, string model, string ipv4)
        {
            _validator = new HardwareValidation();
            Id = id;
            Name = name;
            IsOnline = false;
            Description = description;
            Model = model;
            Ipv4 = ipv4;

            _validator.ValidateAndThrow(this);
        }

        public void Uptime(string description, string name, string model, string ipv4)
        {
            Name = name.ToLower();
            Description = description;
            Model = model;
            Ipv4 = ipv4;

            UpDate();
            _validator.ValidateAndThrow(this);
        }
    }
}
