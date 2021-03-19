using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.SalesItems.Contracts
{
    public interface SalesItemServices
    {
        Task<int> Add(AddSalesItemDto dto);
    }
}
