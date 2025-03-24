namespace Admin.Shared.Response.Expression;

public class ExpressionResponse
{
    public long Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Second { get; private set; } = string.Empty;
    public string Minute { get; private set; } = string.Empty;
    public string Hour { get; private set; } = string.Empty;
    public string Day { get; private set; } = string.Empty;
    public string Month { get; private set; } = string.Empty;
    public string Weesday { get; private set; } = string.Empty;
}