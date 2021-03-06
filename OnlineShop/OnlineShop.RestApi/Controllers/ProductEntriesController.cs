using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.ProductEntries.Contracts;

namespace OnlineShop.RestApi.Controllers
{
    [ApiController,Route("api/product-entries")]
    public class ProductEntriesController : Controller
    {
        private readonly ProductEntryServices _services;

        public ProductEntriesController(ProductEntryServices services)
        {
            _services = services;
        }

        [HttpPost]
        public async Task<int> Add(AddProductEntryDto dto)
        {
            return await _services.Add(dto);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _services.Delete(id);
        }

        [HttpGet]
        public async Task<IList<GetAllProductEntryDto>> GetAll()
        {
            return await _services.GetAll();
        }
    }
}