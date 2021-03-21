using OnlineShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.ProductEntries.Contracts
{
    public interface ProductEntryServices
    {
        Task<int> Add(AddProductEntryDto dto);
        Task Delete(int id);
    }
}
