using ECommerce.Common.Data;
using ECommerce.Common.Data.Models;
using Hangfire;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Common.Messages
{
    public class MessagesHostedService : IHostedService
    {
        //using of IServiceSCopeFactory for hosted services 
        //https://stackoverflow.com/questions/48368634/how-should-i-inject-a-dbcontext-instance-into-an-ihostedservice
        private readonly IServiceScopeFactory scopeFactory;

        public MessagesHostedService(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var recurringJobManager = scope.ServiceProvider.GetRequiredService<IRecurringJobManager>();
                recurringJobManager.AddOrUpdate(nameof(MessagesHostedService), () => this.ProcessPendingMessages(), "*/5 * * * * *");
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public void ProcessPendingMessages()
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var publisher = scope.ServiceProvider.GetService<IBus>();
                var data = scope.ServiceProvider.GetService<DbContext>();

                if (publisher == null || data == null)
                    return;

                var messages = data.Set<Message>().Where(x => !x.Published).ToList();

                foreach (var m in messages)
                {
                    publisher.Publish(m.Data, m.Type);
                    m.Published = true;
                    data.SaveChanges();
                }
            }
        }
    }
}
