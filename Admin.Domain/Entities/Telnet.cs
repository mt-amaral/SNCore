using Admin.Domain.Validations;
using FluentValidation;


namespace Admin.Domain.Entities;

public class Telnet : BaseEntity
{
    public int Id { get; private set; }
    public string User { get; private set; }
    public string Password { get; private set; }
    public int Port { get; private set; }

    public int HardwareId { get; set; }
    public Hardware Hardware { get; set; }
    private readonly IValidator<Telnet> _validator;

    public Telnet(int id, string user, string password, int port)
    {
        _validator = new TelnetValidation();
        Id = id;
        User = user;
        Password = password;
        Port = port;
        
        _validator.ValidateAndThrow(this);
    }
    public void Update(string user, string password, int port)
    {
        User = user;
        Password = password;
        Port = port;

        UpDate();
        _validator.ValidateAndThrow(this);
    }
};
