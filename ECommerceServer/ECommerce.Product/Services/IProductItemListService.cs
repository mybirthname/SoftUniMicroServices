using ECommerce.Product.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Product.Services
{
    public interface IProductItemListService
    {
        Task<ProductItemList> SaveEntity(ProductItemList model);

        Task<IEnumerable<ProductItemList>> GetList();

    }
}
