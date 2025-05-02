
using Admin.Domain.Interfaces;
using Quartz;
using Microsoft.Extensions.DependencyInjection;

namespace Admin.Application.Scheduling;
public class RuntimeJob : IJob
{
    private readonly IServiceProvider _sp;

    public RuntimeJob(IServiceProvider sp)
        => _sp = sp;

    public async Task Execute(IJobExecutionContext context)
    {

        // pega o Id passado no trigger
        var id = context.MergedJobDataMap.GetString("ItemId");

        // ... sua lógica aqui
        Console.WriteLine($"[RuntimeJob] executando item {id} em {DateTime.Now}");
    }
}