using Admin.Application.Hub;
using Admin.Connection.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Quartz;

namespace Admin.Application.Scheduling;
public class RuntimeJob : IJob
{
    private readonly IServiceProvider _sp;
    private readonly IHubContext<NotificationHub> _hub;
    private readonly ISnmpConnection _snmpConnection;

    public RuntimeJob(IServiceProvider sp, IHubContext<NotificationHub> hub, ISnmpConnection snmpConnection)
    {
        _sp = sp;
        _hub = hub;
        _snmpConnection = snmpConnection;
    }
    public async Task Execute(IJobExecutionContext context)
    {
        try
        {
            // pega o Id passado no trigger
            var id = context.MergedJobDataMap.GetString("ItemId");
            var teste =  _snmpConnection.PerformOperation("192.168.77.233", 161, "public", "1.3.6.1.2.1.1.3.0");
            var resultado = teste.First().Data.ToString();
            _hub.Clients.All.SendAsync("teste", $"UPTIME:{resultado}");
            // ... sua lógica aqui
            Console.WriteLine($"ROTINA: {id} HOST:192.168.77.233 {resultado}");

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }
}