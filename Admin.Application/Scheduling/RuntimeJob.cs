using Admin.Application.Hub;
using Admin.Connection.Interfaces;
using Admin.Shared.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Quartz;

namespace Admin.Application.Scheduling;
public class RuntimeJob : IJob
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IHubConnectionSocket _hubConnectionSocket;
    private readonly ISnmpConnection _snmpConnection;

    public RuntimeJob(IServiceProvider serviceProvider, IHubConnectionSocket hubConnectionSocket, ISnmpConnection snmpConnection)
    {
        _serviceProvider = serviceProvider;
        _hubConnectionSocket = hubConnectionSocket;
        _snmpConnection = snmpConnection;
    }
    public async Task Execute(IJobExecutionContext context)
    {

            // pega o Id passado no trigger
            var id = context.MergedJobDataMap.GetString("ItemId");
            //var teste =  _snmpConnection.PerformOperation("192.168.77.233", 161, "public", "1.3.6.1.2.1.1.3.0");
            //var resultado = teste.First().Data.ToString();
             await _hubConnectionSocket.NotifyAsync($"ROTINA: {DateTime.Now}");
    }
}