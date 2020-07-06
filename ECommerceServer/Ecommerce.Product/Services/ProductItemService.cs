using AutoMapper;
using Ecommerce.Product.Data;
using Ecommerce.Product.Data.Models;
using ECommerce.Common.Services;
using ECommerce.Product.Models;
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

        public ProductItemService(ProductDbContext db, IMapper mapper) : base(db)
            => this.mapper = mapper;

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

            return this.mapper.Map<ProductItemOutputModel>(data);
        }

    }
}
