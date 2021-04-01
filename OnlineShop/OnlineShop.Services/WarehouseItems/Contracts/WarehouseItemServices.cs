using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.WarehouseItems.Contracts
{
    public interface WarehouseItemServices
    {
        Task<IList<GetAllWarehouseItemsDto>> GetAll(string filter, int pageId);
    }
}
