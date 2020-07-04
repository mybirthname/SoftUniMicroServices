using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Product.Data.Models
{
    public class Product
    {
        public Guid ID { get; set; }

        public string Title { get; set; }

        public string NrIntern { get; set; }

        public decimal PricePerPQ { get; set; }

        public string URL { get; set; }

        public string Description { get; set; }

        public Guid SupplierID { get; set; }
    }
}
