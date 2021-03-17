using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.ProductCategories.Contracts;

namespace OnlineShop.RestApi.Controllers
{
    [ApiController,Route("api/product-categories")]
    public class ProductCategoriesController : Controller
    {
        private readonly ProdcutCategoryServices _services;

        public ProductCategoriesController(ProdcutCategoryServices services)
        {
            _services = services;
        }

        [HttpPost]
        public async Task Add(AddProductCategoryDto dto)
        {
           await _services.Add(dto);
        }
    }
}