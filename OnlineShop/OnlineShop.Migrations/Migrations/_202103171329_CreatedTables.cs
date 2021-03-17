using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Migrations.Migrations
{
    [Migration(202103171329)]
    public class _202103171329_CreatedTables : Migration
    {

        public override void Up()
        {
            Create.Table("ProductCategories")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Title").AsString(50).NotNullable();

            Create.Table("Products")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Title").AsString(50).NotNullable()
                .WithColumn("Code").AsString(20).NotNullable()
                .WithColumn("MinimumStack").AsInt32().NotNullable()
                .WithColumn("ProductCategoryId").AsInt32().NotNullable()
                    .ForeignKey("FK_Products_ProductCategories", "ProductCategories", "Id");

            Create.Table("WarehouseItems")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Count").AsInt32().NotNullable()
                .WithColumn("ProductId").AsInt32().NotNullable()
                    .ForeignKey("FK_WarehouseItems_Products", "Products", "Id");

            Create.Table("ProductEntries")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Count").AsInt32().NotNullable()
                .WithColumn("NumberFactor").AsString(20).NotNullable()
                .WithColumn("CreateDate").AsDateTime().NotNullable()
                .WithColumn("ProductId").AsInt32().NotNullable()
                    .ForeignKey("FK_ProductEntries_Products", "Products", "Id");

            Create.Table("SalesInvoices")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("CustomerName").AsString(50).NotNullable()
                .WithColumn("Number").AsString(20).NotNullable()
                .WithColumn("CreateDate").AsDateTime().NotNullable();

            Create.Table("SalesItems")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Count").AsInt32().NotNullable()
                .WithColumn("Price").AsDecimal().NotNullable()
                .WithColumn("SalesInvoiceId").AsInt32().NotNullable()
                    .ForeignKey("FK_SalesItems_SalesInvoices", "SalesInvoices", "Id")
                .WithColumn("ProductId").AsInt32().NotNullable()
                    .ForeignKey("FK_SalesItems_Products", "Products", "Id");

            Create.Table("AccountingDocuments")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Number").AsString(20).NotNullable()
                .WithColumn("NumberInvoice").AsString(20).NotNullable()
                .WithColumn("TotalPrice").AsDecimal().NotNullable()
                .WithColumn("CreateDate").AsDateTime().NotNullable()
                .WithColumn("SalesInvoiceId").AsInt32().NotNullable()
                    .ForeignKey("FK_AccountingDocuments_SalesInvoices", "SalesInvoices", "Id");
        }
        public override void Down()
        {
            Delete.Table("AccountingDocuments"); 
            Delete.Table("SalesItems"); 
            Delete.Table("SalesInvoices"); 
            Delete.Table("ProductEntries"); 
            Delete.Table("WarehouseItems"); 
            Delete.Table("Products"); 
            Delete.Table("ProductCategories");
        }
    }
}
