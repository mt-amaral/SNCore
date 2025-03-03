using System.ComponentModel.DataAnnotations;

namespace Admin.Shared.Request.Host;

public class CreateHostRequest
{
    [Required]
    [MaxLength(50, ErrorMessage = "O nome não pode ter mais de 50 caracteres.")]
    public string Name { get; set; } = string.Empty;
    [Required]
    [RegularExpression(@"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$", ErrorMessage = "O IP fornecido não é válido.")]
    [MaxLength(15, ErrorMessage = "O IP fornecido não é válido.")]
    public string Ipv4 { get; set; } = "0.0.0.0";
    [MaxLength(50, ErrorMessage = "O descrição não pode ter mais de 50 caracteres.")]
    public string Description { get; set; } = string.Empty;
    public int? GroupId { get; set; } = null;
    public int? ModelId { get; set; } = null;
    public SnmpRequest? Snmp { get; set; } = null;
    public TelnetRequest? Telnet { get; set; } = null;
}

