using Microsoft.EntityFrameworkCore;
using OnlineShop.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace OnlineShop.Persistence.EF
{
    public class EFDataContext:DbContext
    {
        public EFDataContext(DbContextOptions<EFDataContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyAssemblyConfigurations(typeof(EFDataContext).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AccountingDocument> AccountingDocuments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductEntry> ProductEntries { get; set; }
        public DbSet<SalesInvoice> SalesInvoices { get; set; }
        public DbSet<SalesItem> SalesItems { get; set; }
        public DbSet<WarehouseItem> WarehouseItems { get; set; }
    }
}
