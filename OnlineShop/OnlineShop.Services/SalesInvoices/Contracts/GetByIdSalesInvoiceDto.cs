using System;

namespace OnlineShop.Services.SalesInvoices.Contracts
{
    public class GetByIdSalesInvoiceDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string NumberInvoice { get; set; }
        public DateTime CreateDate { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
    }
}