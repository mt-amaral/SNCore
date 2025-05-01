using Microsoft.Extensions.DependencyInjection;

namespace Admin.Application.Scheduling;

using Quartz;
using Quartz.Spi;

public class ScopedJobFactory : IJobFactory
{
    private readonly IServiceProvider _sp;
    public ScopedJobFactory(IServiceProvider sp) 
        => _sp = sp;

    public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        => (IJob)_sp.CreateScope()
            .ServiceProvider
            .GetRequiredService(bundle.JobDetail.JobType);

    public void ReturnJob(IJob job) { /* nada */ }
}