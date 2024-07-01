using Admin.Domain.Validations;
using FluentValidation;

namespace Admin.Domain.Entities
{
    public class Hardware
    {
        public int Id { get; private set; }
        public string Description { get; private set; }
        public string Model { get; private set; }
        public string Ipv4 { get; private set; }

        public Snmp Snmp { get; set; }
        public Telnet Telnet { get; set; }

        private readonly IValidator<Hardware> _validator;

        public Hardware(int id, string description, string model, string ipv4)
        {
            _validator = new HardwareValidation();
            Id = id;
            Description = description;
            Model = model;
            Ipv4 = ipv4;

            _validator.ValidateAndThrow(this);
        }

        public void Update(string description, string model, string ipv4)
        {
            Description = description;
            Model = model;
            Ipv4 = ipv4;

            _validator.ValidateAndThrow(this);
        }
    }
}
