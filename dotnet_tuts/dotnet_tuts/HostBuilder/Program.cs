using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HostBuilder;
using Microsoft.Extensions.Configuration;
using HostBuilder.Services;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureHostConfiguration(configHost =>
    {
        configHost.SetBasePath(Directory.GetCurrentDirectory());
        var env = Environment.GetEnvironmentVariable("DOTNETCORE_ENVIRONMENT");
        configHost.AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true);
        configHost.AddEnvironmentVariables(prefix: "DOTNETCORE_");
        configHost.AddCommandLine(args);
    })
    .ConfigureServices((context, services) => {
        services.AddHostedService<Worker>();
        services.AddScoped<IMyService, MyService>();
    })
    .Build();

await host.RunAsync();