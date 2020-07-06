using ECommerce.Common.Models.Interfaces;
using ECommerce.Product.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Product.Data.Models
{
    public class ProductItem : IMapFrom<ProductItemInputModel>
    {
        public Guid ID { get; set; }

        public string Title { get; set; }

        public string NrIntern { get; set; }

        public decimal PricePerPQ { get; set; }

        public string URL { get; set; }

        public string Description { get; set; }

        public Guid SupplierID { get; set; }

        public int DeliveryTime { get; set; }
    }
}
