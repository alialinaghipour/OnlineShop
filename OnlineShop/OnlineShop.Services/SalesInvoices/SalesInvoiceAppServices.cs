using OnlineShop.Entities;
using OnlineShop.Infrastructure.Application;
using OnlineShop.Services.SalesInvoices.Contracts;
using OnlineShop.Services.SalesInvoices.Exceptions;
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

        public SalesInvoiceAppServices(
            UnitOfWork unitOfWork,
            SalesInovoiceRepository salesInovoiceRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = salesInovoiceRepository;
        }

        public async Task<int> Add(AddSalesInvoiceDto dto)
        {
            await CheckedExistsByNumber(dto.Number);

            SalesInvoice salesInvoice = new SalesInvoice()
            {
                CreateDate = DateTime.Now,
                CustomerName = dto.CustomerName,
                Number = dto.Number
            };

            decimal firstPrice = 0;

            var accounting = new HashSet<AccountingDocument>()
            {
                 new AccountingDocument()
                {
                SalesInvoiceId = salesInvoice.Id,
                CreateDate = DateTime.Now,
                Number ="dsedfgfaaccbf",
                NumberInvoice = dto.Number,
                TotalPrice=firstPrice
                }
            };

            salesInvoice.AccountingDocuments = accounting;

            _repository.Add(salesInvoice);

            _unitOfWork.Complate();

            return salesInvoice.Id;
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
