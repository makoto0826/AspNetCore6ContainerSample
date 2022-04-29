using System.Diagnostics;
using OpenTelemetry;
using OpenTelemetry.Contrib.Extensions.AWSXRay.Trace;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

Sdk.SetDefaultTextMapPropagator(new AWSXRayPropagator());

var serviceName = "HelloWorld";
var serviceVersion = "1.0.0";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenTelemetryTracing(builder =>
{
    var resourceBuilder = ResourceBuilder.CreateDefault()
        .AddService(serviceName: serviceName, serviceVersion: serviceVersion)
        .AddTelemetrySdk();

    builder
          .AddSource(serviceName)
          .SetResourceBuilder(resourceBuilder)
          .AddAspNetCoreInstrumentation()
          .AddAWSInstrumentation()
          .AddXRayTraceId()
          .AddOtlpExporter();
})
.AddSingleton(TracerProvider.Default.GetTracer(serviceName));

var app = builder.Build();

app.MapGet("/", () =>
{
    var source = new ActivitySource("HelloWorld");

    using (var activity = source.StartActivity("Hello"))
    {
        activity?.SetTag("foo", 1);
        activity?.SetTag("bar", "Hello, World!");
        activity?.SetTag("baz", new int[] { 1, 2, 3 });
        activity?.SetStatus(ActivityStatusCode.Ok);
    }

    var logger = app.Services.GetRequiredService<ILogger<Program>>();
    logger.LogInformation("Hello World");
    return "Hello World";
});

app.Run();
