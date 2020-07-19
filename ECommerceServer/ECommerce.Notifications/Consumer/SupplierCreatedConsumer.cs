using ECommerce.Common.Messages.Supplier;
using ECommerce.Notifications.Hubs;
using MassTransit;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Notifications.Consumer
{
    public class SupplierCreatedConsumer : IConsumer<SupplierCreatedMessage>
    {
        private readonly IHubContext<NotificationsHub> hub;

        public SupplierCreatedConsumer(IHubContext<NotificationsHub> hub)
        {
            this.hub = hub;
        }

        public async Task Consume(ConsumeContext<SupplierCreatedMessage> context)
        {
            await hub.Clients.Groups(Constants.AuthenticatedUsersGroup).SendAsync(Constants.ReceiveNotificationMessage, context.Message);
        }
    }
}
