using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Product.Data.Models;
using ECommerce.Common.Controllers;
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
        public ProductController(IProductItemService service)
        {
            this.service = service;
        }

        public IActionResult T()
        {
            return new OkResult();
        }

        [HttpGet]
        [Authorize]
        [Route(nameof(GetList))]
        public async Task<IEnumerable<ProductItemOutputModel>> GetList()
            =>await service.GetList();

        [HttpGet]
        [Authorize]
        [Route(nameof(GetByID))]

        public async Task<ProductItemOutputModel> GetByID(Guid id)
            => await service.GetByID(id);

        [HttpPost]
        [Authorize]
        [Route(nameof(Save))]
        public async Task<ProductItemOutputModel> Save(ProductItemInputModel model)
            => await service.Save(model);
    }
}
