using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OnlineShop.Infrastructure.Application;
using OnlineShop.Persistence.EF;
using OnlineShop.Persistence.EF.ProductCategories;
using OnlineShop.Persistence.EF.ProductEntries;
using OnlineShop.Persistence.EF.Products;
using OnlineShop.Persistence.EF.SalesInvoices;
using OnlineShop.Persistence.EF.SalesItems;
using OnlineShop.Persistence.EF.WarehouseItems;
using OnlineShop.PersistenceEF.WarehouseItems;
using OnlineShop.Services.ProductCategories;
using OnlineShop.Services.ProductCategories.Contracts;
using OnlineShop.Services.ProductEntries;
using OnlineShop.Services.ProductEntries.Contracts;
using OnlineShop.Services.Products;
using OnlineShop.Services.Products.Contracts;
using OnlineShop.Services.SalesInvoices;
using OnlineShop.Services.SalesInvoices.Contracts;
using OnlineShop.Services.SalesItems;
using OnlineShop.Services.SalesItems.Contracts;
using OnlineShop.Services.WarehouseItems;
using OnlineShop.Services.WarehouseItems.Contracts;

namespace OnlineShop.RestApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<EFDataContext>(options =>
            {
                options.UseSqlServer("Server=.;Database=OnlineShop_12;Trusted_Connection=True;");
            });

            services.AddScoped<UnitOfWork, EFUnitOfWork>();

            services.AddScoped<ProductCategoryRepository, EFProductCategoryRepository>();
            services.AddScoped<ProdcutCategoryServices, ProductCategoryAppServices>();

            services.AddScoped<ProductRepository, EFProductRepository>();
            services.AddScoped<ProductServices, ProductAppServices>();

            services.AddScoped<ProductEntryRepository, EFProductEntryRepository>();
            services.AddScoped<ProductEntryServices, ProductEntryAppServices>();

            services.AddScoped<WarehouseItemRepository, EFWarehouseItemRepository>();
            services.AddScoped<WarehouseItemServices, WarehouseItemAppServices>();

            services.AddScoped<SalesInovoiceRepository, EFSalesInvoiceRepository>();
            services.AddScoped<SalesInvoiceServices, SalesInvoiceAppServices>();

            services.AddScoped<SalesItemsRepository, EFSalesItemRepository>();
            services.AddScoped<SalesItemServices, SalesItemAppServices>();

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
