using AutoMapper;
using ECommerce.Common.Services;
using ECommerce.Supplier.Data;
using ECommerce.Supplier.Model;
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

        public SupplierService(SupplierDbContext db, IMapper mapper):base(db)
        {
            this.mapper = mapper;
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

            return this.mapper.Map<SupplierOutputModel>(data);

        }
    }
}
