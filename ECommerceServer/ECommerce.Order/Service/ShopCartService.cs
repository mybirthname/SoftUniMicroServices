using AutoMapper;
using ECommerce.Common.Services;
using ECommerce.Ordering.Data;
using ECommerce.Ordering.Data.Models;
using ECommerce.Ordering.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Ordering.Service
{
    public class ShopCartService : DataService<ShoppingCart>, IShopCartService
    {
        private readonly IMapper mapper;

        public ShopCartService(OrderingDbContext db, IMapper mapper) : base(db)
        {
            this.mapper = mapper;
        }

        public async Task<ShopCartOutputModel> GetByID(Guid id)
            => await this.mapper
                .ProjectTo<ShopCartOutputModel>(this
                    .All()
                    .Where(d => d.ID == id))
                .FirstOrDefaultAsync();


        public async Task<IEnumerable<ShopCartOutputModel>> GetList()
            => await this.mapper.ProjectTo<ShopCartOutputModel>(this.All()).ToListAsync();


        public async Task<ShopCartOutputModel> Save(ShopCartInputModel model)
        {
            var data = this.mapper.Map<ShoppingCart>(model);

            await Save(data);

            return this.mapper.Map<ShopCartOutputModel>(data);

        }

    }
}
