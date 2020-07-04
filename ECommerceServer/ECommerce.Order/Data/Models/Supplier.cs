using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Order.Data.Models
{
    public class Supplier
    {
        public Guid ID { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
    }
}
