using AutoMapper;
using ECommerce.Common.Services;
using ECommerce.Product.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Product.Services
{
    public class ProductItemListService : DataService<ProductItemList>, IProductItemListService
    {
        private readonly IMapper mapper;

        public ProductItemListService(DbContext db, IMapper mapper) : base(db)
        {
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ProductItemList>> GetList()
            => await this.All().ToListAsync();
        

        public async Task<ProductItemList> SaveEntity(ProductItemList model)
        {
            await Save(model);

            await this.Data.SaveChangesAsync();

            return model;
        }
    }
}
