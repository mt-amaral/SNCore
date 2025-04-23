using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.Shared.Request.Account;

public class LoginRequest
{
    [Required]
    [MaxLength(255, ErrorMessage = "O nome não pode ter mais de 255 caracteres.")]
    public string Username { get; set; } = string.Empty;

    [Required]
    [NotMapped]
    [MinLength(8, ErrorMessage = "O mínimo 8  caracteres.")]
    [MaxLength(100, ErrorMessage = "O máximo 100 caracteres.")]
    public string Password { get; set; } = string.Empty;
}