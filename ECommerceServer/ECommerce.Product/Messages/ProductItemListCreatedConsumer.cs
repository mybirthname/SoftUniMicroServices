using ECommerce.Common.Messages.Product;
using ECommerce.Common.Services.Messages;
using ECommerce.Product.Data.Models;
using ECommerce.Product.Services;
using MassTransit;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Product.Messages
{
    public class ProductItemListCreatedConsumer : IConsumer<ProductItemCreatedMessage>
    {
        private readonly ISupplierService supplierService;
        private readonly IProductItemListService productItemListService;
        private readonly IMessageService messageService;

        public ProductItemListCreatedConsumer(ISupplierService supplierService, IProductItemListService productItemListService, IMessageService messageService)
        {
            this.supplierService = supplierService;
            this.productItemListService = productItemListService;
            this.messageService = messageService;
        }


        public async Task Consume(ConsumeContext<ProductItemCreatedMessage> context)
        {
            var message = context.Message;
            var dbMessage = await messageService.GetByID(message.ID);

            var r = await supplierService.GetByID(message.SupplierID);

            ProductItemList l = new ProductItemList { 
                DeliveryTime = message.DeliveryTime,
                Description = message.Description,
                ID = message.ProductItemID,
                NrIntern = message.NrIntern,
                PricePerPQ = message.PricePerPQ,
                SupplierEmail = r.Email,
                SupplierName = r.Name,
                Title = message.Title,
                URL = message.URL
            };

            await productItemListService.SaveEntity(l);

        }
    }
}
