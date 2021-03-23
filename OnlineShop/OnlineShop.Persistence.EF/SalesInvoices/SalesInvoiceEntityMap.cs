using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Entities;

namespace OnlineShop.Persistence.EF.SalesInvoices
{
    class SalesInvoiceEntityMap : IEntityTypeConfiguration<SalesInvoice>
    {
        public void Configure(EntityTypeBuilder<SalesInvoice> _)
        {
            _.ToTable("SalesInvoices");

            _.HasKey(_ => _.Id);

            _.Property(_ => _.Id).IsRequired().ValueGeneratedOnAdd();

            _.Property(_ => _.CustomerName).IsRequired().HasMaxLength(50);

            _.Property(_ => _.Number).IsRequired().HasMaxLength(20);

            _.Property(_ => _.CreateDate).IsRequired();

        }
    }
}
