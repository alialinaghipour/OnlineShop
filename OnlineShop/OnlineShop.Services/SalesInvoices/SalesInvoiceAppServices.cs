using OnlineShop.Entities;
using OnlineShop.Infrastructure.Application;
using OnlineShop.Services.Products.Exceptions;
using OnlineShop.Services.SalesInvoices.Contracts;
using OnlineShop.Services.SalesInvoices.Exceptions;
using OnlineShop.Services.WarehouseItems.Contracts;
using OnlineShop.Services.WarehouseItems.Exceprions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.SalesInvoices
{
    public class SalesInvoiceAppServices : SalesInvoiceServices
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly SalesInovoiceRepository _repository;
        private readonly WarehouseItemRepository _warehouseItemRepository;

        public SalesInvoiceAppServices(
            UnitOfWork unitOfWork,
            SalesInovoiceRepository salesInovoiceRepository,
            WarehouseItemRepository warehouseItemRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = salesInovoiceRepository;
            _warehouseItemRepository = warehouseItemRepository;
        }

        public async Task<int> Add(AddSalesInvoiceDto dto)
        {
            await CheckedExistsByNumber(dto.Number);

            var salesInvoice = new SalesInvoice()
            {
                CreateDate = DateTime.Now,
                CustomerName = dto.CustomerName,
                Number = dto.Number
            };

            decimal totalPrice = 0;
            totalPrice = await AddSalesItemsToSalesInvoice(dto.SalesItemDtos, salesInvoice, totalPrice);

            AddAccountingDocumentForSalesInvoice(salesInvoice, totalPrice);

            _repository.Add(salesInvoice);
            _unitOfWork.Complate();
            return salesInvoice.Id;
        }

        private void AddAccountingDocumentForSalesInvoice
            (SalesInvoice salesInvoice, decimal totalPrice)
        {
            var accounting = new HashSet<AccountingDocument>()
            {
                 new AccountingDocument()
                {
                SalesInvoiceId = salesInvoice.Id,
                CreateDate = DateTime.Now,
                Number =DateTime.Now.ToShortDateString(),
                NumberInvoice = salesInvoice.Number,
                TotalPrice=totalPrice
                }
            };
            salesInvoice.AccountingDocuments = accounting;
        }

        private async Task<decimal> AddSalesItemsToSalesInvoice
            (HashSet<SalesItemDto> dto, SalesInvoice salesInvoice, decimal totalPrice)
        {
            var selasItems = new HashSet<SalesItem>();
            foreach (var item in dto)
            {
                var warehousItem = await _warehouseItemRepository.FindByProductCode(item.ProductCode);
                CheckedExistsProductToWarehouse(warehousItem);
                CheckedStackInWarehouse(warehousItem.Count, item.Count);
                CheckedMinimumStackInProduct(warehousItem.Product.MinimumStack, warehousItem.Count);
                selasItems.Add(new SalesItem
                {
                    Count = item.Count,
                    SalesInvoiceId = salesInvoice.Id,
                    Price = item.Price,
                    ProductId = warehousItem.ProductId,
                });
                totalPrice += (item.Price * item.Count);
                warehousItem.Count -= item.Count;
            }
            salesInvoice.SalesItems = selasItems;
            return totalPrice;
        }

        private void CheckedExistsProductToWarehouse(WarehouseItem warehouse)
        {
            if (warehouse == null)
            {
                throw new ProductNotFoundException();
            }
        }

        private void CheckedStackInWarehouse(int countWarehouse,int salesCount)
        {
            if (countWarehouse < salesCount)
            {
                throw new NotStockInWarehouseException();
            }
        }

        private void CheckedMinimumStackInProduct(int minimumStack, int warehuose)
        {
            if (minimumStack >= warehuose)
            {
                throw new NotStockInWarehouseException();
            }
        }

        private async Task CheckedExistsByNumber(string number)
        {
            if (await _repository.IsExistsByNumber(number))
            {
                throw new DuplicateInvoiceNumberException();
            }
        }
        public async Task<GetByIdSalesInvoiceDto> GetById(int id)
        {
            var invoice = await _repository.FindById(id);
            CheckedExsitsSalesInvoice(invoice);

            int count = 0;
            foreach (var item in invoice.SalesItems)
            {
                count += item.Count;
            }

            decimal price = 0;
            foreach (var item in invoice.AccountingDocuments)
            {
                price += item.TotalPrice;
            }

            GetByIdSalesInvoiceDto dto = new GetByIdSalesInvoiceDto()
            {
                Count = count,
                TotalPrice = price,
                NumberInvoice = invoice.Number,
                CustomerName = invoice.CustomerName,
                CreateDate = invoice.CreateDate,
                Id = invoice.Id
            };

            return dto;
        }

        private void CheckedExsitsSalesInvoice(SalesInvoice invoice)
        {
            if (invoice == null)
            {
                throw new SalesInvoiceNotFoundException();
            }
        }
    }
}
