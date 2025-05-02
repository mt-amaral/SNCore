using Admin.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;

namespace Admin.Application.Scheduling;

public class JobScheduler : IHostedService
{
    private readonly ISchedulerFactory _schedulerFactory;
    private readonly IServiceProvider  _sp;
    private IScheduler                _scheduler;

    public JobScheduler(ISchedulerFactory schedulerFactory, IServiceProvider sp)
    {
        _schedulerFactory = schedulerFactory;
        _sp               = sp;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _scheduler = await _schedulerFactory.GetScheduler(cancellationToken);
        _scheduler.JobFactory = new ScopedJobFactory(_sp);
        await _scheduler.Start(cancellationToken);
        await RefreshJobsAsync(cancellationToken);  // carrega só no boot
    }

    public async Task StopAsync(CancellationToken cancellationToken)
        => await _scheduler?.Shutdown(cancellationToken);
    
    
    public async Task RefreshJobsAsync(CancellationToken ct = default)
    {
        await _scheduler.Clear();  
        using var scope = _sp.CreateScope();
        var repo = scope.ServiceProvider.GetRequiredService<IRunTimeRepository>();
        var list = await repo.GetActiveAsync(ct);
        foreach (var item in list.Where(x => !string.IsNullOrWhiteSpace(x?.CronExpression?.GetExpression(x.CronExpression))))
        {
            var job = JobBuilder.Create<RuntimeJob>()
                .WithIdentity($"job-{item!.Id.ToString()}")
                .UsingJobData("ItemId", item.Id.ToString())
                .Build();

            // aplica sua regra de "?" aqui
            var cron = item.CronExpression.GetExpression(item.CronExpression);
            var trigger = TriggerBuilder.Create()
                .WithIdentity($"trigger-{item.Id}")
                .WithCronSchedule(cron)
                .Build();

            await _scheduler.ScheduleJob(job, trigger, ct);
        }
    }


}