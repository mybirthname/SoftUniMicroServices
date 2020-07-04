using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Order.Data.Models
{
    public class OrderItem
    {
        public Guid ID { get; set; }

        public string Title { get; set; }

        public string NrIntern { get; set; }

        public DateTime DeliveryDate { get; set; }

        public Guid SupplierID { get; set; }

        public decimal AmountNet { get; set; }

        public Guid UserID { get; set; }
    }
}
