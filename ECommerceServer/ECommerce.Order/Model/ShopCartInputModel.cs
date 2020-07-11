using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Ordering.Model
{
    public class ShopCartInputModel
    {
        public Guid ID { get; set; }

        public Guid UserID { get; set; }

        public decimal AmountNet { get; set; }


    }
}
