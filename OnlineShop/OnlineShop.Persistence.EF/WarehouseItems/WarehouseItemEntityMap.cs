using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Entities;

namespace OnlineShop.Persistence.EF.WarehouseItems
{
    class WarehouseItemEntityMap : IEntityTypeConfiguration<WarehouseItem>
    {
        public void Configure(EntityTypeBuilder<WarehouseItem> _)
        {
            _.ToTable("WarehouseItems");

            _.HasKey(_ => _.Id);

            _.Property(_ => _.Id).IsRequired().ValueGeneratedOnAdd();

            _.Property(_ => _.Count).IsRequired();

            _.Property(_ => _.ProductId).IsRequired();

            _.HasOne(_ => _.Product)
                .WithMany(_ => _.WarehouseItems)
                .HasForeignKey(_ => _.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
