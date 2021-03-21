using OnlineShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.ProductEntries.Contracts
{
    public interface ProductEntryRepository
    {
        void Add(ProductEntry productEntry);
        void Delete(ProductEntry productEntry);
        Task<ProductEntry> FindById(int id);
    }
}
