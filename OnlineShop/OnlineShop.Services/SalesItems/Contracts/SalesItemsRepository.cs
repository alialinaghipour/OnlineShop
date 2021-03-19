using OnlineShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.SalesItems.Contracts
{
    public interface SalesItemsRepository
    {
        void Add(SalesItem salesItem);
    }
}
