using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Entities;

namespace OnlineShop.Persistence.EF.Products
{
    class ProductEntityMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> _)
        {
            _.ToTable("Products");

            _.HasKey(_ => _.Id);

            _.Property(_ => _.Id).IsRequired().ValueGeneratedOnAdd();

            _.Property(_ => _.Title).IsRequired().HasMaxLength(50);

            _.Property(_ => _.Code).IsRequired().HasMaxLength(20);

            _.Property(_ => _.MinimumStack).IsRequired();

            _.Property(_ => _.ProductCategoryId).IsRequired();

            _.HasOne(_ => _.ProductCategory)
                .WithMany(_ => _.Products)
                .HasForeignKey(_ => _.ProductCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
