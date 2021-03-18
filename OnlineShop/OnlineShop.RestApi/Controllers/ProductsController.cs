using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.Products.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.RestApi.Controllers
{
    [ApiController,Route("api/products")]
    public class ProductsController : Controller
    {
        private readonly ProductServices _services;

        public ProductsController(ProductServices services)
        {
            _services = services;
        }

        [HttpPost]
        public async Task<int> Add(AddProductDto dto)
        {
            return await _services.Add(dto);
        }

        [HttpGet("{id}")]
        public async Task<GetByIdProductDto> GetById(int id)
        {
            return await _services.GetById(id);
        }
    }
}
