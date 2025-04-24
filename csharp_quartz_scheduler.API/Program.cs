using CrystalQuartz.AspNetCore;
using csharp_quartz_scheduler.API.Extensions;
using csharp_quartz_scheduler.API.Jobs;
using Quartz;
using Quartz.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDependencies(builder);

//IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
//await scheduler.Start();

//builder.Services.AddSingleton(scheduler);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseHealthChecks("/health");

//app.UseCrystalQuartz(() => scheduler);

app.UseAuthorization();

app.MapControllers();

app.Run();
