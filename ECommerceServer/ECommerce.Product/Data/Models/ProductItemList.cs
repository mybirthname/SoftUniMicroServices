using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Product.Data.Models
{
    public class ProductItemList
    {
        public Guid ID { get; set; }

        public string Title { get; set; }

        public string NrIntern { get; set; }

        public decimal PricePerPQ { get; set; }

        public string URL { get; set; }

        public string Description { get; set; }

        public string SupplierEmail { get; set; }

        public string SupplierName { get; set; }

        public int DeliveryTime { get; set; }

    }
}
