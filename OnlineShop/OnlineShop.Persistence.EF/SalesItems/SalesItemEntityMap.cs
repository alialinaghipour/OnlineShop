using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Entities;

namespace OnlineShop.Persistence.EF.SalesItems
{
    class SalesItemEntityMap : IEntityTypeConfiguration<SalesItem>
    {
        public void Configure(EntityTypeBuilder<SalesItem> _)
        {
            _.ToTable("SalesItems");

            _.HasKey(_ => _.Id);

            _.Property(_ => _.Id).IsRequired().ValueGeneratedOnAdd();

            _.Property(_ => _.Count).IsRequired();

            _.Property(_ => _.Price).IsRequired();

            _.Property(_ => _.SalesInvoiceId).IsRequired();

            _.Property(_ => _.ProductId).IsRequired();

            _.HasOne(_ => _.SalesInvoice)
                .WithMany(_ => _.SalesItems)
                .HasForeignKey(_ => _.SalesInvoiceId)
                .OnDelete(DeleteBehavior.Restrict);

            _.HasOne(_ => _.Product)
               .WithMany(_=>_.SalesItems)
               .HasForeignKey(_ => _.ProductId)
               .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
