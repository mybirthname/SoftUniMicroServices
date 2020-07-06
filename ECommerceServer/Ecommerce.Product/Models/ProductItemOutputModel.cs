using Ecommerce.Product.Data.Models;
using ECommerce.Common.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Product.Models
{
    public class ProductItemOutputModel : IMapFrom<ProductItem>
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
