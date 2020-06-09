using Easy.Commerce.Areas.Admin.Data;
using Easy.Commerce.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Easy.Commerce.Areas.Admin.Services
{
    public class AdminEfService : IAdminService
    {
        private readonly AdminDBContext adminDbContext;

        public AdminEfService(AdminDBContext adminContext)
        {
            adminDbContext = adminContext;
        }

        public IList<CategoryModel> GetCategories()
        {
            return adminDbContext.Categories.ToList();
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
            return adminDbContext.Products.Include(c => c.Category).ToList();
        }
    }
}