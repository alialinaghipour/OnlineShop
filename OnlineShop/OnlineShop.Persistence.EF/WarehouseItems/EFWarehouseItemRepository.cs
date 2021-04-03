using Microsoft.EntityFrameworkCore;
using OnlineShop.Entities;
using OnlineShop.Persistence.EF;
using OnlineShop.Services.WarehouseItems.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.PersistenceEF.WarehouseItems
{
    public class EFWarehouseItemRepository : WarehouseItemRepository
    {
        private readonly EFDataContext _context;
        private readonly DbSet<WarehouseItem> _set;

        public EFWarehouseItemRepository(EFDataContext context)
        {
            _context = context;
            _set = _context.WarehouseItems;
        }

        public async Task<WarehouseItem> FindByProductCode(string code)
        {
            return await _set
                .Include(_=>_.Product)
                .SingleOrDefaultAsync(_ => _.Product.Code == code);
        }
        
        public async Task<IList<GetAllWarehouseItemsDto>> GetAll(FilterWarehouseForRepositoryDto filterDto)
        {
            var warehouseItemsDto = FilterWarehouseItems(filterDto);
            warehouseItemsDto = SortWarehouseItems(warehouseItemsDto, filterDto.IsAscending);
            return await warehouseItemsDto.ToListAsync();
        }

        private IQueryable<GetAllWarehouseItemsDto> FilterWarehouseItems(FilterWarehouseForRepositoryDto filterDto)
        {
            return _set
                .Where(_ => EF.Functions.Like(_.Product.Title, $"%{filterDto.Filter}%")
                      || EF.Functions.Like(_.Product.Code, $"%{filterDto.Filter}%"))
                .Skip(filterDto.Skip)
                .Take(filterDto.Take)
                .Select(_ => new GetAllWarehouseItemsDto()
                {
                    MinimumStock = _.Product.MinimumStack,
                    Stock = _.Count,
                    productName = _.Product.Title,
                    ProductCategroy = _.Product.ProductCategory.Title,
                    ProductCode = _.Product.Code,
                });
        }

        private IQueryable<GetAllWarehouseItemsDto> SortWarehouseItems(IQueryable<GetAllWarehouseItemsDto> warehouseItemsDtos,bool isAscending)
        {
            if (isAscending)
            {
                warehouseItemsDtos = warehouseItemsDtos.OrderBy(_ => _.productName);
            }
            else
            {
                warehouseItemsDtos = warehouseItemsDtos.OrderByDescending(_ => _.productName);
            }
            return warehouseItemsDtos;
        }

        public async Task<int> CountProdcutByFilter(string filter)
        {
            return await _set
                .CountAsync(_ => EF.Functions.Like(_.Product.Title, $"%{filter}%")
                           || EF.Functions.Like(_.Product.Code, $"%{filter}%"));
        }

        public void Delete(WarehouseItem warehouseItem)
        {
            _set.Remove(warehouseItem);
        }
    }
}
