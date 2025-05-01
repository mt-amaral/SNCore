
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

        // cria escopo p/ pegar repositório
        using var scope = _sp.CreateScope();
        var repo = scope.ServiceProvider.GetRequiredService<IRunTimeRepository>();
        var item = (await repo.GetActiveAsync())
            .FirstOrDefault(x => x.Id.ToString() == id);

        if (item is null)
            return;

        // ... sua lógica aqui
        Console.WriteLine($"[RuntimeJob] executando item {id} em {DateTime.Now}");



    }
}