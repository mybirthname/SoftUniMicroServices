using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Common.Controllers;
using ECommerce.Common.Infrastructure;
using ECommerce.Supplier.Model;
using ECommerce.Supplier.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Supplier.Controllers
{
    public class SupplierController : ApiController
    {

        private readonly ISupplierService service;
        public SupplierController(ISupplierService service)
        {
            this.service = service;
        }

        [HttpGet]
        [AuthorizeAdministrator]
        [Route(nameof(GetList))]
        public async Task<IEnumerable<SupplierOutputModel>> GetList()
            => await service.GetList();

        [HttpGet]
        [AuthorizeAdministrator]
        [Route(nameof(GetByID))]

        public async Task<SupplierOutputModel> GetByID(Guid id)
            => await service.GetByID(id);

        [HttpPost]
        [Authorize]
        [Route(nameof(Save))]
        public async Task<SupplierOutputModel> Save(SupplierInputModel model)
            => await service.Save(model);


    }


}
