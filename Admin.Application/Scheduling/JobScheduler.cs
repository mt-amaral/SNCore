using Admin.Domain.Entities;
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
        foreach (var item in list.Where(x => !string.IsNullOrWhiteSpace(x?.CronExpression?.GetExpression())))
        {
            var job = JobBuilder.Create<RuntimeJob>()
                .WithIdentity($"job-{item!.Id.ToString()}")
                .UsingJobData("ItemId", item.Id.ToString())
                .Build();

            var cron = item.CronExpression.GetExpression();
            var trigger = TriggerBuilder.Create()
                .WithIdentity($"trigger-{item.Id}")
                .WithCronSchedule(cron)
                .Build();

            await _scheduler.ScheduleJob(job, trigger, ct);
        }
    }
    
    public async Task AddJobAsync(RunTime item, CancellationToken ct = default)
    {
        var jobKey = new JobKey($"job-{item.Id.ToString()}");
        var triggerKey = new TriggerKey($"trigger-{item.Id.ToString()}");
        await _scheduler.DeleteJob(jobKey, ct);
        
        var cron = item.CronExpression.GetExpression();
        if (string.IsNullOrWhiteSpace(cron))
            return;
        
        var job = JobBuilder.Create<RuntimeJob>()
            .WithIdentity(jobKey)
            .UsingJobData("ItemId", item.Id.ToString())
            .Build();
        
        var trigger = TriggerBuilder.Create()
            .WithIdentity(triggerKey)
            .WithCronSchedule(cron)
            .Build();
        
        await _scheduler.ScheduleJob(job, trigger, ct);
    }

    public async Task RemoveJobAsync(Guid jobsId, CancellationToken ct = default)
    {
        var jobKey = new JobKey($"job-{jobsId.ToString()}");
        await _scheduler.DeleteJob(jobKey, ct);
    }

}