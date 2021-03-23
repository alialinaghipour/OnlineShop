using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.SalesInvoices.Exceptions
{
    class SalesInvoiceNotFoundException:Exception
    {
        public override string Message => "این فاکتور وجود ندارد";
    }
}
