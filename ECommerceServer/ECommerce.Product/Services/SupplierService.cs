using AutoMapper;
using Ecommerce.Product.Data;
using ECommerce.Common.Services;
using ECommerce.Product.Data.Models;
using ECommerce.Product.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Product.Services
{
    public class SupplierService : DataService<Supplier>, ISupplierService
    {
        private readonly IMapper mapper;

        public SupplierService(ProductDbContext db, IMapper mapper) :base(db)
        {
            this.mapper = mapper;
        }
        public async Task<SupplierOutputModel> GetByID(Guid id)
        {
            return await this.mapper
                  .ProjectTo<SupplierOutputModel>(this
                      .All()
                      .Where(d => d.ID == id))
                  .FirstOrDefaultAsync();
        }

        public async Task<SupplierOutputModel> SaveEntity(Supplier model)
        {

            var result = this.All().FirstOrDefault(x => x.ID == model.ID);

            if (result != null)
                this.Data.Update(model);
            else
                this.Data.Add(model);

            await this.Data.SaveChangesAsync();

            return this.mapper.Map<SupplierOutputModel>(model);

        }
    }
}
