using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Entities;

namespace OnlineShop.Persistence.EF.ProductEntries
{
    public class ProdcutEntryEntityMap : IEntityTypeConfiguration<ProductEntry>
    {
        public void Configure(EntityTypeBuilder<ProductEntry> _)
        {
            _.ToTable("ProductEntries");

            _.HasKey(_ => _.Id);

            _.Property(_ => _.Id).IsRequired().ValueGeneratedOnAdd();

            _.Property(_ => _.Count).IsRequired();

            _.Property(_ => _.NumberFactor).IsRequired().HasMaxLength(20);

            _.Property(_ => _.CreateDate).IsRequired();

            _.Property(_ => _.ProductId).IsRequired();

            _.HasOne(_ => _.product)
                .WithMany()
                .HasForeignKey(_ => _.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
