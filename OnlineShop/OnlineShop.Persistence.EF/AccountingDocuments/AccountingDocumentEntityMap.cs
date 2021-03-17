using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Entities;

namespace OnlineShop.Persistence.EF.AccountingDocuments
{
    public class AccountingDocumentEntityMap : IEntityTypeConfiguration<AccountingDocument>
    {
        public void Configure(EntityTypeBuilder<AccountingDocument> _)
        {
            _.ToTable("AccountingDocuments");

            _.HasKey(_ => _.Id);

            _.Property(_ => _.Id).IsRequired().ValueGeneratedOnAdd();

            _.Property(_ => _.Number).IsRequired();

            _.Property(_ => _.NumberInvoice).IsRequired();

            _.Property(_ => _.TotalPrice).IsRequired();

            _.Property(_ => _.CreateDate).IsRequired();

            _.Property(_ => _.SalesInvoiceId).IsRequired();

            _.HasOne(_ => _.SalesInvoice)
                .WithMany(_ => _.AccountingDocuments)
                .HasForeignKey(_ => _.SalesInvoiceId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
