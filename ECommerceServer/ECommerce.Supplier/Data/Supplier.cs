﻿using ECommerce.Common.Models.Interfaces;
using ECommerce.Supplier.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Supplier.Data
{
    public class Supplier : IMapFrom<SupplierInputModel>
    {
        public Guid ID { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Bank { get; set; }
        public string IBAN { get; set; }

        public string NrIntern { get; set; }
    }
}
