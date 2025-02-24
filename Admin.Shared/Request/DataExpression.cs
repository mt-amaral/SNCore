namespace Admin.Shared.Request;

public class DataExpressionRequest
{
    public int ItemId { get; set; }
    public int HostId { get; set; } 
    public string Second { set; get; } = "0";
    public string Minute { get; set; } = "*";
    public string Hour { get; set; } = "*";
    public string Day { get; set; } = "*";
    public string Month { get; set; } = "*";
    public string Weesday { get; set; } = "*";
    
}