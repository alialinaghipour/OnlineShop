using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.Products.Contracts
{
    public interface ProductServices
    {
        Task<int> Add(AddProductDto dto);
        Task<GetByIdProductDto> GetById(int id);
        Task Delete(int id);
    }
}
