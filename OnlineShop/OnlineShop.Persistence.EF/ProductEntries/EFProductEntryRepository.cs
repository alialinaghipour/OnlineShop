using Microsoft.EntityFrameworkCore;
using OnlineShop.Entities;
using OnlineShop.Services.ProductEntries.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Persistence.EF.ProductEntries
{
    public class EFProductEntryRepository : ProductEntryRepository
    {
        private readonly EFDataContext _context;
        private readonly DbSet<ProductEntry> _set;

        public EFProductEntryRepository(EFDataContext context)
        {
            _context = context;
            _set = context.ProductEntries;
        }

        public void Add(ProductEntry productEntry)
        {
            _set.Add(productEntry);
        }
    }
}
