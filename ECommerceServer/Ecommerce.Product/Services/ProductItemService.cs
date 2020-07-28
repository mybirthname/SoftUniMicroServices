using AutoMapper;
using Ecommerce.Product.Data;
using Ecommerce.Product.Data.Models;
using ECommerce.Common.Data.Models;
using ECommerce.Common.Messages.Product;
using ECommerce.Common.Services;
using ECommerce.Product.Data.Models;
using ECommerce.Product.Models;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Product.Services
{
    public class ProductItemService: DataService<ProductItem>, IProductItemService
    {

        private readonly IMapper mapper;
        private readonly IBus bus;

        public ProductItemService(ProductDbContext db, IMapper mapper, IBus bus) : base(db)
        {
            this.mapper = mapper;
            this.bus = bus;
        }

        public async Task<IEnumerable<ProductItemOutputModel>> GetList()
            => await this.mapper.ProjectTo<ProductItemOutputModel>(this.All()).ToListAsync();

        public async Task<ProductItemOutputModel> GetByID(Guid id)
            => await this.mapper
                .ProjectTo<ProductItemOutputModel>(this
                    .All()
                    .Where(d => d.ID == id))
                .FirstOrDefaultAsync();

        public async Task<ProductItemOutputModel> Save(ProductItemInputModel model)
        {
            var data = this.mapper.Map<ProductItem>(model);

            await Save(data);

            var messageData = new ProductItemCreatedMessage
            {
                ProductItemID = data.ID,
                NrIntern = data.NrIntern,
                Title = data.Title,
                SupplierID = data.SupplierID,
                DeliveryTime = data.DeliveryTime,
                PricePerPQ = data.PricePerPQ,
                Description = data.Description,
                URL = data.URL
            };

            var m = new Message(messageData, messageData.ID);
            await Save(data, m);

            await this.bus.Publish(messageData);
            await MarkMessageAsPublished(m.ID);

            return this.mapper.Map<ProductItemOutputModel>(data);
        }

    }
}
