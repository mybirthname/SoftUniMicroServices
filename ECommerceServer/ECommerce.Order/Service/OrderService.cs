using AutoMapper;
using ECommerce.Common.Services;
using ECommerce.Order.Data.Models;
using ECommerce.Ordering.Data;
using ECommerce.Ordering.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Ordering.Service
{
    public class OrderService: DataService<OrderItem>, IOrderService
    {
        private readonly IMapper mapper;

        public OrderService(OrderingDbContext db, IMapper mapper) : base(db)
        {
            this.mapper = mapper;
        }

        public async Task<OrderItemOutputModel> GetByID(Guid id)
            => await this.mapper
                .ProjectTo<OrderItemOutputModel>(this
                    .All()
                    .Where(d => d.ID == id))
                .FirstOrDefaultAsync();


        public async Task<IEnumerable<OrderItemOutputModel>> GetList()
            => await this.mapper.ProjectTo<OrderItemOutputModel>(this.All()).ToListAsync();


        public async Task<OrderItemOutputModel> Save(OrderItemInputModel model)
        {
            var data = this.mapper.Map<OrderItem>(model);

            await Save(data);

            return this.mapper.Map<OrderItemOutputModel>(data);

        }

    }
}
