using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Common.Messages.Product
{
    public class ProductItemCreatedMessage
    {
        public Guid ID { get; set; } = Guid.NewGuid();

        public string Title { get; set; }

        public string NrIntern { get; set; }

        public decimal PricePerPQ { get; set; }

        public string URL { get; set; }

        public string Description { get; set; }

        public Guid SupplierID { get; set; }
        public Guid ProductItemID { get; set; }

        public int DeliveryTime { get; set; }
        
    }
}
