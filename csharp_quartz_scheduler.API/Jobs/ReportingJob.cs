using Quartz;

namespace csharp_quartz_scheduler.API.Jobs;

[DisallowConcurrentExecution]
public class ReportingJob : IJob
{
    public Task Execute(IJobExecutionContext context)
    {
        Console.WriteLine("Report executing...");
        return Task.CompletedTask;
    }
}
