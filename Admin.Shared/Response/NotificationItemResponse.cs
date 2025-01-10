

namespace Admin.Shared.Response;

public class NotificationItemResponse
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public DateTime Time { get; set; } = DateTime.Now;

}
