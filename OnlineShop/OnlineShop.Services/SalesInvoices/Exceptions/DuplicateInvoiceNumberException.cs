using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.SalesInvoices.Exceptions
{
    public class DuplicateInvoiceNumberException:Exception
    {
        public override string Message => "این شماره فاکتور تکراری است";
    }
}
