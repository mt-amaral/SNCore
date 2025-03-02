using System.ComponentModel.DataAnnotations;

namespace Admin.Shared.Request.Expression;

public class CreateExpressionRequest
{
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "ItemId deve ser maior que 0.")]
    public int ItemId { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "HostId deve ser maior que 0.")]
    public int HostId { get; set; }
    public CronExpressionRequest Expression { get; set; } = null!;
}