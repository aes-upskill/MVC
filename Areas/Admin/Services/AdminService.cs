using Easy.Commerce.Areas.Admin.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Easy.Commerce.Areas.Admin.Services
{
    public class AdminService: IAdminService
    {
        private readonly string productJsonFile = "products.json";
        private readonly string categoryJsonFile = "categories.json";
        private readonly ILogger<AdminService> logger;
        public AdminService(ILogger<AdminService> logger)
        {
            this.logger = logger;
            productJsonFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", productJsonFile);
            categoryJsonFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", categoryJsonFile);
        }

        public IList<ProductModel> GetProducts()
        {
            logger.LogInformation("Begin GetProducts");
            var products = JsonConvert.DeserializeObject<IList<ProductModel>>(System.IO.File.ReadAllText(@productJsonFile));
            var categories = GetCategories();
            foreach (var product in products)
            {
                product.Category = categories.FirstOrDefault(p => p.CategoryID == product.CategoryID);
            }
            return products;
        }

        public IList<CategoryModel> GetCategories()
        {
            logger.LogInformation("Begin GetCategories");
            return JsonConvert.DeserializeObject<IList<CategoryModel>>(System.IO.File.ReadAllText(categoryJsonFile));
        }

        public void BulkUpdateProducts()
        {
            // code 
        }

        public void SaveProduct(ProductModel product)
        {
            var products = GetProducts();
            if (products.Any(x => x.ProductID == product.ProductID))
            {
                var editedProduct = products.First(x => x.ProductID == product.ProductID);
                editedProduct.Code = product.Code;
                editedProduct.Name = product.Name;
                editedProduct.CategoryID = product.CategoryID;
                editedProduct.ModifiedDate = DateTime.UtcNow;
            }
            else
            {
                product.CreatedDate = DateTime.UtcNow;
                product.ModifiedDate = DateTime.UtcNow;
                product.ProductID = products.Count + 1;
                products.Add(product);
            }
            System.IO.File.WriteAllText(productJsonFile, JsonConvert.SerializeObject(products));
        }

        public ProductModel GetProductById(int productID)
        {
            var products = GetProducts();
            return products.FirstOrDefault(x => x.ProductID == productID);
        }
    }
}
