using Microsoft.EntityFrameworkCore;
using OnlineShop.Entities;
using OnlineShop.Services.WarehouseItems.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.EF.WarehouseItems
{
    public class EFWarehouseItemRepository : WarehouseItemRepository
    {
        private readonly EFDataContext _context;
        private readonly DbSet<WarehouseItem> _set;

        public EFWarehouseItemRepository(EFDataContext context)
        {
            _context = context;
            _set = context.WarehouseItems;
        }

        public async Task<WarehouseItem> FindByProductCode(string code)
        {
            return await _set.SingleOrDefaultAsync(_ => _.Product.Code == code);
        }
    }
}
