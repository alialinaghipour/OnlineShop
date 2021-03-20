using Microsoft.EntityFrameworkCore;
using OnlineShop.Entities;
using OnlineShop.Services.WarehouseItems.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IList<GetAllWarehouseItemsDto>> GetAll()
        {
            var query =
                (from warehouse in _set
                 join product in _context.Products
                 on warehouse.ProductId equals product.Id
                 join category in _context.ProductCategories
                 on product.ProductCategoryId equals category.Id
                 select new GetAllWarehouseItemsDto()
                 {
                     productName = product.Title,
                     ProductCode = product.Code,
                     ProductCategroy = category.Title,
                     MinimumStock = product.MinimumStack,
                     Stock = warehouse.Count
                 }).ToListAsync();
            return await query;
        }

        public async Task<IList<GetAllWarehouseItemsDto>> GetAll
            (string filter,int skip,int take)
        {
            return await _set
                .Where(_ => _.Product.Title.Contains(filter))
                .Skip(skip)
                .Take(take)
                .Select(_ => new GetAllWarehouseItemsDto()
                {
                    MinimumStock = _.Product.MinimumStack,
                    Stock = _.Count,
                    productName = _.Product.Title,
                    ProductCategroy = _.Product.ProductCategory.Title,
                    ProductCode = _.Product.Code,
                })
                .ToListAsync();
        }

        public async Task<int> CountInSearch(string filter)
        {
            return await _set.Where(_ => _.Product.Title.Contains(filter))
                .Select(_ => _.Count).CountAsync();
        }
    }
}
