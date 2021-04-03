using OnlineShop.Infrastructure.Application;
using OnlineShop.Services.WarehouseItems.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.WarehouseItems
{
    public class WarehouseItemAppServices : WarehouseItemServices
    {
        private readonly WarehouseItemRepository _repository;

        public WarehouseItemAppServices(WarehouseItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<GetAllWarehouseItemsDto>> GetAll(FilterWarehouseForServices filterDto, int pageId)
        {
            var CountProduct = await _repository.CountProdcutByFilter(filterDto.Filter);

            int take = 2;
            int totalPageCount= (int)Math.Ceiling((double)CountProduct / take);
            if (totalPageCount < pageId || pageId==0)
            {
                pageId = 1;
            }
            int skip = (pageId - 1) * take;

            FilterWarehouseForRepositoryDto filterWarehouseForRepositoryDto = new FilterWarehouseForRepositoryDto()
            {
                Filter = filterDto.Filter,
                Take = take,
                Skip = skip,
                IsAscending = filterDto.IsAscending
            };

            return await _repository.GetAll(filterWarehouseForRepositoryDto);
        }
    }
}
