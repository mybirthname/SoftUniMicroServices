using ECommerce.Supplier.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Supplier.Services
{
    public interface ISupplierService
    {
        Task<SupplierOutputModel> Save(SupplierInputModel model);
        Task<SupplierOutputModel> GetByID(Guid id);
        Task<IEnumerable<SupplierOutputModel>> GetList();

    }
}
