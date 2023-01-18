using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostBuilder.Services
{
    class MyService : IMyService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        public MyService(IConfiguration configuration, ILogger<MyService> logger) { 
            _configuration = configuration;
            _logger = logger;
        }
        public void DoSomeThing()
        {
            _logger.LogInformation($"params: {_configuration["foo"]}");
            _logger.LogInformation($"environment variables: {_configuration["TEST"]}");
        }
    }
}
