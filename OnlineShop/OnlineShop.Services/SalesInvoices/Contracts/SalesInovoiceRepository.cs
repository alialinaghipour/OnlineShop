using OnlineShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.SalesInvoices.Contracts
{
    public interface SalesInovoiceRepository
    {
        void Add(SalesInvoice salesInvoice);
        Task<bool> IsExistsByNumber(string number);
        Task<SalesInvoice> FindByNumber(string number);
        Task<SalesInvoice> FindById(int id);
    }
}
