using Admin.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Quartz.Spi;

namespace Admin.Application.Scheduling;

using Quartz;
using Microsoft.Extensions.Hosting;

public class QuartzScheduler : IHostedService
{
    private readonly ISchedulerFactory _sf;
    private readonly IJobFactory     _jf;
    private readonly IServiceProvider _sp;
    private IScheduler _sched;

    public QuartzScheduler(
        ISchedulerFactory sf,
        IJobFactory jf,
        IServiceProvider sp)
    {
        _sf = sf;
        _jf = jf;
        _sp = sp;
    }

    public async Task StartAsync(CancellationToken ct)
    {
        _sched = await _sf.GetScheduler(ct);
        _sched.JobFactory = _jf;

        // busca ativos
        using var scope = _sp.CreateScope();
        var repo = scope.ServiceProvider.GetRequiredService<IRunTimeRepository>();
        var list = await repo.GetActiveAsync(ct);

        foreach (var item in list.Where(x => !string.IsNullOrWhiteSpace(x?.CronExpression?.GetExpression(x.CronExpression))))
        {
            var expression = item!.CronExpression.GetExpression(item.CronExpression);
            var job = JobBuilder.Create<RuntimeJob>()
                .WithIdentity($"job-{item.Id.ToString()}")
                .UsingJobData("ItemId", item.Id.ToString())
                .Build();

            var trig = TriggerBuilder.Create()
                .WithIdentity($"trg-{item.Id}")
                .WithCronSchedule(expression)
                .Build();

            await _sched.ScheduleJob(job, trig, ct);
        }

        await _sched.Start(ct);
    }

    public async Task StopAsync(CancellationToken ct)
        => await _sched.Shutdown(ct);
}