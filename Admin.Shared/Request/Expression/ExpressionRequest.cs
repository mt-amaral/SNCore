using System.ComponentModel.DataAnnotations;

namespace Admin.Shared.Request.Expression;

public class ExpressionRequest
{
    [Required(ErrorMessage = "O campo 'Second' é obrigatório.")]
    [RegularExpression(@"^(\*|(\d{1,2})(,\d{1,2})*|(\d{1,2}-\d{1,2})|(\*/\d+))$", ErrorMessage = "Valor inválido para Second.")]
    public string Second { get; set; } = "0";

    [Required(ErrorMessage = "O campo 'Minute' é obrigatório.")]
    [RegularExpression(@"^(\*|(\d{1,2})(,\d{1,2})*|(\d{1,2}-\d{1,2})|(\*/\d+))$", ErrorMessage = "Valor inválido para Minute.")]
    public string Minute { get; set; } = "*";

    [Required(ErrorMessage = "O campo 'Hour' é obrigatório.")]
    [RegularExpression(@"^(\*|(\d{1,2})(,\d{1,2})*|(\d{1,2}-\d{1,2})|(\*/\d+))$", ErrorMessage = "Valor inválido para Hour.")]
    public string Hour { get; set; } = "*";

    [Required(ErrorMessage = "O campo 'Day' é obrigatório.")]
    [RegularExpression(@"^(\*|(\d{1,2})(,\d{1,2})*|(\d{1,2}-\d{1,2})|(\*/\d+))$", ErrorMessage = "Valor inválido para Day.")]
    public string Day { get; set; } = "*";

    [Required(ErrorMessage = "O campo 'Month' é obrigatório.")]
    [RegularExpression(@"^(\*|(\d{1,2}|jan|feb|mar|apr|may|jun|jul|aug|sep|oct|nov|dec)(,(\d{1,2}|jan|feb|mar|apr|may|jun|jul|aug|sep|oct|nov|dec))*(\d{1,2}-\d{1,2})?(\*/\d+)?)$", ErrorMessage = "Valor inválido para 'Month'.")]
    public string Month { get; set; } = "*";

    [Required(ErrorMessage = "O campo 'Weekday' é obrigatório.")]
    [RegularExpression(@"^(\*|(\d|sun|mon|tue|wed|thu|fri|sat)(,(\d|sun|mon|tue|wed|thu|fri|sat))*(\d-\d)?(\*/\d+)?)$", ErrorMessage = "Valor inválido para 'Weekday'.")]
    public string Weesday { get; set; } = "*";
}