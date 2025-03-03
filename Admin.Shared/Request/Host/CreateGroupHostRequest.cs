
using System.ComponentModel.DataAnnotations;

namespace Admin.Shared.Request.Host;

public class CreateGroupHostRequest
{
    [MaxLength(50, ErrorMessage = "O nome não pode ter mais de 50 caracteres.")]

    public string GroupName { get; set; } = string.Empty;
}
