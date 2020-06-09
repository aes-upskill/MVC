using Easy.Commerce.Areas.Admin.Data;
using Easy.Commerce.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;
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
            // not implemented
        }

        IList<ProductModel> IAdminService.GetProducts()
        {
            return adminDbContext.Products.Include(c => c.Category).ToList();
        }
    }
}