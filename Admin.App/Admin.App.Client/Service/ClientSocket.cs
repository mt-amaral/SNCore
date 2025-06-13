using System.Security.Cryptography.X509Certificates;
using Admin.Shared.Interfaces;
using Microsoft.AspNetCore.SignalR.Client;

namespace Admin.App.Client.Service;

public class ClientSocket : IHubConnectionSocket
{
    private readonly HubConnection _hub;

    public ClientSocket(IConfiguration configuration)
    {
        var hubUrl = configuration["ApiServer:ws"] + "/hubs/notification";
        
        _hub = new HubConnectionBuilder()
            .WithUrl(hubUrl)
            .WithAutomaticReconnect()
            .Build();

        _hub.Closed += async (error) =>
        {
            await Task.Delay(new Random().Next(0,5) * 1000);
            await _hub.StartAsync();
        };
    }

    public  async Task NotifyAsync(string notification)
    {
       await _hub.InvokeAsync("Notify", notification);
    }
}