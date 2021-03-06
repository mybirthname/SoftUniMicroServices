using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Common.Infrastructure;
using ECommerce.Common.Services.Messages;
using ECommerce.Ordering.Data;
using ECommerce.Ordering.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ECommerce.Order
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
            .AddWebService<OrderingDbContext>(this.Configuration)
            .AddTransient<IOrderService, OrderService>()
            .AddTransient<IShopCartService, ShopCartService>()
            .AddTransient<IMessageService, MessageService>()
            .AddHangFireServices(Configuration);


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        => app.UseWebService(env)
            .Initialize();
    }
}
