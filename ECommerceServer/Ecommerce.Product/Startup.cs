using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Product.Data;
using Ecommerce.Product.Data.Models;
using ECommerce.Common.Infrastructure;
using ECommerce.Product.Messages;
using ECommerce.Product.Services;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Product
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
            .AddWebService<ProductDbContext>(this.Configuration)
            .AddTransient<IProductItemService, ProductItemService>()
            .AddTransient<ISupplierService, SupplierService>()
            .AddMessaging(this.Configuration, typeof(SupplierCreatedConsumer))
            .AddHangFireServices(this.Configuration);


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        => app.UseWebService(env)
            .Initialize();
    }
}
