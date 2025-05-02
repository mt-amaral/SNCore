using Admin.Application.Hub;
using Microsoft.AspNetCore.SignalR;
using Quartz;

namespace Admin.Application.Scheduling;
public class RuntimeJob : IJob
{
    private readonly IServiceProvider _sp;
    private readonly IHubContext<NotificationHub> _hub;

    public RuntimeJob(IServiceProvider sp, IHubContext<NotificationHub> hub)
    {
        _sp = sp;
        _hub = hub;
    }
    public async Task Execute(IJobExecutionContext context)
    {
        // pega o Id passado no trigger
        var id = context.MergedJobDataMap.GetString("ItemId");

        _hub.Clients.All.SendAsync($"[RuntimeJob] executando item {id} em {DateTime.Now}");
        // ... sua lógica aqui
        Console.WriteLine($"[RuntimeJob] executando item {id} em {DateTime.Now}");
    }
}