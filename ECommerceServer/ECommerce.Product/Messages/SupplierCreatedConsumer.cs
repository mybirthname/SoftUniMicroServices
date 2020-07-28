using ECommerce.Common.Messages.Supplier;
using ECommerce.Common.Services.Messages;
using ECommerce.Product.Data.Models;
using ECommerce.Product.Services;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Product.Messages
{
    public class SupplierCreatedConsumer : IConsumer<SupplierCreatedMessage>
    {
        private readonly ISupplierService supplier;
        private readonly IMessageService messageService;

        public SupplierCreatedConsumer(ISupplierService supplier, IMessageService messageService)
        {
            this.supplier = supplier;
            this.messageService = messageService;
        }

        public async Task Consume(ConsumeContext<SupplierCreatedMessage> context)
        {
            var message = context.Message;

            var dbMessage = await messageService.GetByID(message.ID);


            Supplier s = new Supplier()
            {
                ID = message.SupplierID,
                Name = message.Name,
                Email = message.Email
            };

            await supplier.SaveEntity(s);
        }
    }
}
