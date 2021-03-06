using OnlineShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.WarehouseItems.Contracts
{
    public interface WarehouseItemRepository
    {
        Task<WarehouseItem> FindByProductCode(string code);
        Task<IList<GetAllWarehouseItemsDto>> GetAll(string filter, int skip, int take);
        Task<int> CountProdcutByFilter(string filter);
        void Delete(WarehouseItem warehouseItem);
    }
}
