using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.IO;

namespace BetterConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            Log.Logger.Information("starting now...");

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<GreetingsService>();
                })
                .UseSerilog()
                .Build();

            var srv = ActivatorUtilities.CreateInstance<GreetingsService>(host.Services);
            srv.Run();
        }

        public static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        }
    }

    public class GreetingsService
    {
        private readonly ILogger<GreetingsService> _loggger;
        private readonly IConfiguration _config;
        public GreetingsService(ILogger<GreetingsService> logger, IConfiguration config)
        {
            _loggger = logger;
            _config = config;
        }

        public void Run()
        {
            for (int i = 0; i < _config.GetValue<int>("loopTimes"); i++)
            {
                _loggger.LogInformation("item: {num}", i);
            }
        }
    }
}
