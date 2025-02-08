namespace Admin.Shared.Response;

public enum AlertItemIcon : byte
{
    Erro = 0,
    Information = 1,
    Success = 2,
}

public class AlertItemResponse
{
    public long Id { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.Now;
    public string Title { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public string Href { get; set; } = string.Empty;
    public AlertItemIcon TypeAlert { get; set; } = AlertItemIcon.Information;

}