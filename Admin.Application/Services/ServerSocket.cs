using Admin.Application.Hub;
using Admin.Shared.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Admin.Application.Services;

public class ServerSocket : IHubConnectionSocket
{
    
    private readonly IHubContext<NotificationHub> _hub;

    public ServerSocket(IHubContext<NotificationHub> hub)
    {
        _hub = hub;
    }

    public Task NotifyAsync(string notification)
    {
        return _hub.Clients.All.SendAsync("ReceiveMessage", notification);
    }
}