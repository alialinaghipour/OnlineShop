using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.SalesInvoices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.RestApi.Controllers
{
    [ApiController,Route("api/sales-invoices")]
    public class SalesInvoicesController : Controller
    {
        private readonly SalesInvoiceServices _services;

        public SalesInvoicesController(SalesInvoiceServices services)
        {
            _services = services;
        }

        [HttpPost]
        public async Task<int> Add(AddSalesInvoiceDto dto)
        {
            return await _services.Add(dto);
        }
    }
}
