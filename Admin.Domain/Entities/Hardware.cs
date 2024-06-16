using Admin.Domain.Validations;


namespace Admin.Domain.Entities;

public class Hardware
{
    public int Id { get; private set; }
    public string Description { get; private set; }
    public string Model { get; private set; }
    public string Ipv4 { get; private set; }

    public Snmp Snmp { get; set; }
    public Telnet Telnet { get; set; }

    public Hardware(int id, string description, string model, string ipv4)
    {
        DomainValidation.When(id < 0, "Id Não pode ser Negativo");
        Id = id;
        ValidationDomain(description, model, ipv4);

    }
    public void Update(string description, string model, string ipv4)
    {
        ValidationDomain(description, model, ipv4);
    }
    public void ValidationDomain(string description, string model, string ipv4)
    {
        DomainValidation.When(description.Length > 500, "Descricão muito longa");
        DomainValidation.When(model.Length > 300, "Descricão de modelo muito longa");
        DomainValidation.When(ipv4.Length > 15, "Ipv4 Invalido");

        Description = description;
        Model = model;
        Ipv4 = ipv4;
    }
};
