namespace Admin.Shared.Interfaces;

public interface IHubConnectionSocket
{
    Task NotifyAsync(string notification);
}