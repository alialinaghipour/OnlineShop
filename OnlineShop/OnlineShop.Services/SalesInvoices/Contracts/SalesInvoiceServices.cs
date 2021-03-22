using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.SalesInvoices.Contracts
{
    public interface SalesInvoiceServices
    {
        Task<int> Add(AddSalesInvoiceDto dto);
        Task<GetByIdSalesInvoiceDto> GetById(int id);

    }
}
