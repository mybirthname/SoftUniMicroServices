using ECommerce.Common.Models.Interfaces;
using ECommerce.Product.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Product.Models
{
    public class SupplierOutputModel : IMapFrom<Supplier>
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

    }
}
