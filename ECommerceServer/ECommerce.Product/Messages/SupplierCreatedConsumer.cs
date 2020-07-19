using ECommerce.Common.Messages.Supplier;
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

        public SupplierCreatedConsumer(ISupplierService supplier)
        {
            this.supplier = supplier;
        }

        public async Task Consume(ConsumeContext<SupplierCreatedMessage> context)
        {
            var message = context.Message;

            Supplier s = new Supplier()
            {
                ID = message.ID,
                Name = message.Name,
                Email = message.Email
            };

            await supplier.SaveEntity(s);
        }
    }
}
