

using System.ComponentModel.DataAnnotations;

namespace Admin.Shared.Request.Host;

public class TelnetRequest
{
    [MaxLength(30, ErrorMessage = "O user não pode ter mais de 30 caracteres.")]
    public string User { get;  set; } = "admin";
    [MaxLength(100, ErrorMessage = "A senha não pode ter mais de 100 caracteres.")]
    public string Password { get;  set; } = "admin";
    [Range(1, 65535, ErrorMessage = "A porta deve estar entre 1 e 65535.")]
    public int Port { get; private set; } = 23;

}
