using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Serilog;
using Prometheus;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();
builder.Services.AddHealthChecks()
    .AddCheck("self", () => HealthCheckResult.Healthy());
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseHealthChecks("/health");
app.UseMetricServer();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", (Func<string>)(() => "Hello, World!"));

// The tracking endpoint
app.MapPost("/trackActivity", (string activity) => 
{
    Log.Information($"User performed: {activity}");
    // Other business logic
    return Results.Ok($"Tracked: {activity}");
});

app.Run();