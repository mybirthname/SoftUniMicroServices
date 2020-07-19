using ECommerce.Product.Data.Models;
using ECommerce.Product.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Product.Services
{
    public interface ISupplierService
    {
        Task<SupplierOutputModel> SaveEntity(Supplier model);
        Task<SupplierOutputModel> GetByID(Guid id);

    }
}
