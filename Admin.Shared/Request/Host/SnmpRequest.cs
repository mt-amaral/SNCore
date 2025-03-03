using System.ComponentModel.DataAnnotations;

namespace Admin.Shared.Request.Host;

public enum SnmpVersion : byte
{
    V1 = 0,
    V2 = 1,
    V3 = 2
}
public class SnmpRequest
{
    public SnmpVersion SnmpVersion { get; private set; } = SnmpVersion.V2;
    [MaxLength(100, ErrorMessage = "O community não pode ter mais de 100 caracteres.")]
    public string Community { get; set; } = "public";
    [Range(1, 65535, ErrorMessage = "A porta deve estar entre 1 e 65535.")]
    public int Port { get; private set; } = 161;
}

