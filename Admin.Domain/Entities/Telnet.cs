using Admin.Domain.Validations;


namespace Admin.Domain.Entities;

public class Telnet
{
    public int Id { get; private set; }
    public string User { get; private set; }
    public string Password { get; private set; }
    public int Port { get; private set; }

    public int HardwareId { get; set; }
    public Hardware Hardware { get; set; }

    public Telnet(int id, string user, string password, int port)
    {
        DomainValidation.When(id < 0, "Id Não pode ser Negativo");
        Id = id;
        ValidationDomain(user, password, port);

    }
    public void Update(string user, string password, int port)
    {
        ValidationDomain(user, password, port);
    }
    public void ValidationDomain(string user, string password, int port)
    {
        DomainValidation.When(user.Length > 50, "Usuario muito longo ");
        DomainValidation.When(password.Length > 100, "Senha muito longa");
        DomainValidation.When(port > 65536 || port <= 0, "Porta Invalida");

        User = user;
        Password = password;
        Port = port;
    }
};
