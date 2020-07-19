using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Common.Infrastructure;
using ECommerce.Supplier.Data;
using ECommerce.Supplier.Services;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ECommerce.Supplier
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        => services
            .AddWebService<SupplierDbContext>(this.Configuration)
            .AddTransient<ISupplierService, SupplierService>()
            .AddMessaging(Configuration);

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        => app.UseWebService(env)
            .Initialize();
    }
}
