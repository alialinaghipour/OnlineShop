using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.WarehouseItems.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.RestApi.Controllers
{
    [ApiController,Route("api/warehouse-items")]
    public class WarehouseItemsController : Controller
    {
        private readonly WarehouseItemServices _services;

        public WarehouseItemsController(WarehouseItemServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IList<GetAllWarehouseItemsDto>> GetAll(string filter,[Required]int pageing=1)
        {
            return await _services.GetAll(filter, pageing);
        }
    }
}
