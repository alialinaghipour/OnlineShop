using Microsoft.EntityFrameworkCore;
using OnlineShop.Entities;
using OnlineShop.Services.SalesItems.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Persistence.EF.SalesItems
{
    public class EFSalesItemRepository : SalesItemsRepository
    {
        private readonly EFDataContext _context;
        private readonly DbSet<SalesItem> _set;

        public EFSalesItemRepository(EFDataContext context)
        {
            _context = context;
            _set = _context.SalesItems;
        }

        public void Add(SalesItem salesItem)
        {
            _set.Add(salesItem);
        }
    }
}
