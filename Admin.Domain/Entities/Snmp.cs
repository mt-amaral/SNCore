using Admin.Domain.Validations;


namespace Admin.Domain.Entities;


public class Snmp
{
    public int Id { get; private set; }
    public string Version { get; private set; }
    public string Community { get; private set; }
    public int Port { get; private set; }

    public int HardwareId { get; set; }
    public Hardware Hardware { get; set; }


    public Snmp(int id, string version, string community, int port)
    {
        DomainValidation.When(id < 0, "Id Não pode ser Negativo");
        Id = id;
        ValidationDomain(version, community, port);

    }
    public void Update(string version, string community, int port)
    {
        ValidationDomain(version, community, port);
    }
    public void ValidationDomain(string version, string community, int port)
    {
        DomainValidation.When(version.Length > 10, "Versão muito longo ");
        DomainValidation.When(community.Length > 100, "Community muito longa");
        DomainValidation.When(port > 65536 || port <= 0, "Porta Invalida");

        Version = version;
        Community = community;
        Port = port;
    }
};
