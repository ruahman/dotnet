using SampleShop;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;


using SampleShop.Interfaces;
using SampleShop.Services;

[assembly: WebJobsStartup(typeof(Startup))]
namespace SampleShop
{
    using SampleShop.Queries;
    using SampleShop.Services;
    using SampleShop.Utilities;

    public class Startup : IWebJobsStartup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IOrdersService, OrdersService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IAuditService, AuditService>();
            services.AddScoped<GetAllOrdersQuery>();
            services.AddScoped<GetAllItemsQuery>();
            services.AddScoped<GetOrderByIdQuery>();
            services.AddScoped<AddOrderQuery>();
            services.AddScoped<DeleteOrderQuery>();
            services.AddSingleton<ILogger, Logger>();
        }

        public void Configure(IWebJobsBuilder builder)
        {
            ConfigureServices(builder.Services);

        }

    }
}
