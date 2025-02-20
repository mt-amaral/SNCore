

namespace Admin.Shared.Response;

public class ExpressionResponse
{
    public long Id { get; set; }
    
    public string Minute { get; set; } = "*";
    public string Hour { get; set; } = "*";
    public string Day { get; set; } = "*";
    public string Month { get; set; } = "*";
    public string Weesday { get; set; } = "*";
    public string Expression { get; set; } = string.Empty;

}