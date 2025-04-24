using Quartz;

namespace csharp_quartz_scheduler.API.Jobs
{
    [DisallowConcurrentExecution]
    public class SampleJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Job is executed.");
            return Task.CompletedTask;
        }
    }
}
