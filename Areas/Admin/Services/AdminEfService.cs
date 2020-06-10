using Easy.Commerce.Areas.Admin.Data;
using Easy.Commerce.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;

namespace Easy.Commerce.Areas.Admin.Services
{
    public class AdminEfService : IAdminService
    {
        private readonly AdminDBContext adminDbContext;
        private readonly ILogger<AdminEfService> logger;

        public AdminEfService(AdminDBContext adminContext, ILogger<AdminEfService> logger)
        {
            this.logger = logger;
            adminDbContext = adminContext;
        }

        public IList<CategoryModel> GetCategories()
        {
            return adminDbContext.Categories.ToList();
        }

        public void BulkUpdateProducts()
        {
            adminDbContext.Products.Where(x => x.ProductID > 100).Update(x => new ProductModel { ModifiedDate = DateTime.UtcNow.AddDays(-51) });
        }
        public void SaveProduct(ProductModel product)
        {

            if (product.ProductID > 0)
            {
                var productFromDb = adminDbContext.Products.AsNoTracking().Any(x => x.ProductID == product.ProductID);
                if (productFromDb)
                {
                    product.ModifiedDate = DateTime.UtcNow;
                    adminDbContext.Products.Update(product);
                }
                else
                {
                    product.ProductID = 0;
                }
            }
            if (product.ProductID == 0)
            {
                product.CreatedDate = product.ModifiedDate = DateTime.UtcNow;
                adminDbContext.Products.Add(product);
            }
            adminDbContext.SaveChanges();
        }

        IList<ProductModel> IAdminService.GetProducts()
        {
            logger.LogInformation("Begin GetProducts");
            return adminDbContext.Products.Include(c => c.Category).ToList();
        }

        public ProductModel GetProductById(int productID)
        {
            logger.LogInformation($"Begin GetProductById {productID}");
            return adminDbContext.Products.FirstOrDefault(p => p.ProductID == productID);
        }
    }
}