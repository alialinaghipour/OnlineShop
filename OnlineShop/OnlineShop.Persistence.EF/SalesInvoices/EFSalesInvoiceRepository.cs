using Microsoft.EntityFrameworkCore;
using OnlineShop.Entities;
using OnlineShop.Services.SalesInvoices.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.EF.SalesInvoices
{
    public class EFSalesInvoiceRepository : SalesInovoiceRepository
    {
        private readonly EFDataContext _context;
        private readonly DbSet<SalesInvoice> _set;

        public EFSalesInvoiceRepository(EFDataContext context)
        {
            _context = context;
            _set = _context.SalesInvoices;
        }

        public void Add(SalesInvoice salesInvoice)
        {
            _set.Add(salesInvoice);
        }

        public async Task<SalesInvoice> FindByNumber(string number)
        {
            return await _set.Include(_=>_.AccountingDocuments).SingleOrDefaultAsync(_ => _.Number == number);
        }

        public async Task<bool> IsExistsByNumber(string number)
        {
            return await _set.AnyAsync(_ => _.Number == number);
        }
    }
}
