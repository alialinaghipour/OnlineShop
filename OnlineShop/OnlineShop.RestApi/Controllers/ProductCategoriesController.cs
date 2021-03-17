using System;
using System.Collections;
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
        public async Task<int> Add(AddProductCategoryDto dto)
        {
            return await _services.Add(dto);
        }

        [HttpGet]
        public async Task<IList<GetAllProductCategoryDto>> GetAll()
        {
            return await _services.GetAll();
        }
    }
}