using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.SalesItems.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.RestApi.Controllers
{
    [ApiController,Route("api/sales-items")]
    public class SalesItemsController : Controller
    {
        private readonly SalesItemServices _services;

        public SalesItemsController(SalesItemServices services)
        {
            _services = services;
        }

        [HttpPost]
        public async Task<int> Add(AddSalesItemDto dto)
        {
            return await _services.Add(dto);
        }
    }
}
