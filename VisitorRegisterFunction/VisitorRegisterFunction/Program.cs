using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

builder.Services
    .AddApplicationInsightsTelemetryWorkerService()
    .ConfigureFunctionsApplicationInsights();

builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddApplicationInsights(
        configureTelemetryConfiguration: (config) => { },
        configureApplicationInsightsLoggerOptions: (options) => { options.TrackExceptionsAsExceptionTelemetry = true; }
    );

    loggingBuilder.AddFilter<Microsoft.Extensions.Logging.ApplicationInsights.ApplicationInsightsLoggerProvider>(
        "", LogLevel.Information);
});

builder.Build().Run();