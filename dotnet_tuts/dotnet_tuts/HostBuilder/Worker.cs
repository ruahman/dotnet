using HostBuilder.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HostBuilder
{
    class Worker : IHostedService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<Worker> _logger;
        private readonly IMyService _myService;

        public Worker(IConfiguration configuration, ILogger<Worker> logger, IHostApplicationLifetime appLifetime, IMyService myService) {
            _configuration = configuration;
            _logger = logger;
            _myService = myService;
            
            appLifetime.ApplicationStarted.Register(OnStarted);
            appLifetime.ApplicationStopping.Register(OnStopping);
            appLifetime.ApplicationStopped.Register(OnStopped);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("1. StartAsync has been called.");

            _myService.DoSomeThing();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("4. StopAsync has been called.");

            return Task.CompletedTask;
        }

        private void OnStarted()
        {
            _logger.LogInformation("2. OnStarted has been called.");
            var conn = _configuration.GetConnectionString("DefaultConnection");
            _logger.LogInformation($"conn: {conn}");
            _logger.LogInformation($"key1: {_configuration["key1"]}");
            _logger.LogInformation($"key2: {_configuration["key2"]}");
        }

        private void OnStopping()
        {
            _logger.LogInformation("3. OnStopping has been called.");
        }

        private void OnStopped()
        {
            _logger.LogInformation("5. OnStopped has been called.");
        }
    }
}
