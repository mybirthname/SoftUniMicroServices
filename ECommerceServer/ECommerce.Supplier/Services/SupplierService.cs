using AutoMapper;
using ECommerce.Common.Infrastructure;
using ECommerce.Common.Messages.Supplier;
using ECommerce.Common.Services;
using ECommerce.Supplier.Data;
using ECommerce.Supplier.Model;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Supplier.Services
{
    public class SupplierService : DataService<Data.Supplier>, ISupplierService
    {
        private readonly IMapper mapper;
        private readonly IBus bus;

        public SupplierService(SupplierDbContext db, IMapper mapper, IBus bus):base(db)
        {
            this.mapper = mapper;
            this.bus = bus;
        }

        public async Task<SupplierOutputModel> GetByID(Guid id)
            => await this.mapper
                .ProjectTo<SupplierOutputModel>(this
                    .All()
                    .Where(d => d.ID == id))
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<SupplierOutputModel>> GetList()
            => await this.mapper.ProjectTo<SupplierOutputModel>(this.All()).ToListAsync();


        public async Task<SupplierOutputModel> Save(SupplierInputModel model)
        {
            var data = this.mapper.Map<Data.Supplier>(model);

            await Save(data);

            await this.bus.Publish(new SupplierCreatedMessage
            {
                ID = data.ID,
                Name = data.Name,
                Email = data.Email
            });
            
            return this.mapper.Map<SupplierOutputModel>(data);

        }
    }
}
