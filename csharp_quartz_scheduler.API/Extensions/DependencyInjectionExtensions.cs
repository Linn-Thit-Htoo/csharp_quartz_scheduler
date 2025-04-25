using csharp_quartz_scheduler.API.Jobs;
using Quartz;

namespace csharp_quartz_scheduler.API.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddDependencies(this IServiceCollection services, WebApplicationBuilder builder)
    {
        builder.Services.AddQuartz(q =>
        {
            var jobKey = new JobKey("SampleJob");
            q.AddJob<SampleJob>(opts => opts.WithIdentity(jobKey));
            q.AddTrigger(opts => opts
                 .ForJob(jobKey)
                 .WithIdentity("SampleJob_Trigger")
                 .WithCronSchedule("0/5 * * * * ?"));
        });

        builder.Services.AddQuartz(q =>
        {
            var jobKey = new JobKey("ReportJob");
            q.AddJob<ReportingJob>(opts => opts.WithIdentity(jobKey));
            q.AddTrigger(opts => opts
                 .ForJob(jobKey)
                 .WithIdentity("ReportJob_Trigger")
                 .WithCronSchedule("0/5 * * * * ?"));
        });

        builder.Services.AddQuartzHostedService(opt =>
        {
            opt.WaitForJobsToComplete = true;
        });

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddHealthChecks();

        return services;
    }
}
