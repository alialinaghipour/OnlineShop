using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Entities
{
    public class AccountingDocument
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string NumberInvoice { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreateDate { get; set; }


        public int SalesInvoiceId { get; set; }
        public SalesInvoice SalesInvoice { get; set; }
    }
}
