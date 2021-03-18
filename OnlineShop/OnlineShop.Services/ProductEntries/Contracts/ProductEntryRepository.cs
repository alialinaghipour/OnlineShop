using OnlineShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.ProductEntries.Contracts
{
    public interface ProductEntryRepository
    {
        void Add(ProductEntry productEntry);
    }
}
