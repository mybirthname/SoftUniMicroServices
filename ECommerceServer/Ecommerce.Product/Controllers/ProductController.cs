using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Product.Data.Models;
using ECommerce.Common.Controllers;
using ECommerce.Product.Data.Models;
using ECommerce.Product.Models;
using ECommerce.Product.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Product.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductItemService service;
        private readonly ISupplierService supplierService;
        private readonly IProductItemListService productListService;

        public ProductController(IProductItemService service, ISupplierService supplierService, IProductItemListService productListService = null)
        {
            this.service = service;
            this.supplierService = supplierService;
            this.productListService = productListService;
        }

        [HttpGet]
        [Authorize]
        [Route(nameof(GetSupplierList))]
        public async Task<IEnumerable<SupplierOutputModel>> GetSupplierList()
            => await supplierService.GetList();

        [HttpGet]
        [Authorize]
        [Route(nameof(GetSupplierByID))]

        public async Task<SupplierOutputModel> GetSupplierByID(Guid id)
            => await supplierService.GetByID(id);
    


        [HttpGet]
        [Authorize]
        [Route(nameof(GetList))]
        public async Task<IEnumerable<ProductItemList>> GetList()
            =>await productListService.GetList();

        [HttpGet]
        [Authorize]
        [Route(nameof(GetByID))]

        public async Task<ProductItemOutputModel> GetByID(Guid id)
            => await service.GetByID(id);

        [HttpPost]
        [Authorize]
        [Route("save")]
        [Route("save/{id}")]
        public async Task<ProductItemOutputModel> Save(Guid? id, ProductItemInputModel model)
        {
            if (id.HasValue)
                model.ID = id.Value;

            return await service.Save(model);
        }
    }
}
