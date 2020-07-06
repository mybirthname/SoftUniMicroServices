using ECommerce.Product.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Product.Services
{
    public interface IProductItemService
    {
        Task<ProductItemOutputModel> Save(ProductItemInputModel model);
        Task<ProductItemOutputModel> GetByID(Guid id);
        Task<IEnumerable<ProductItemOutputModel>> GetList();
    }
}
