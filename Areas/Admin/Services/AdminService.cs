using Easy.Commerce.Areas.Admin.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Easy.Commerce.Areas.Admin.Services
{
    public class AdminService
    {
        private readonly string productJsonFile = "products.json";
        private readonly string categoryJsonFile = "categories.json";

        public AdminService()
        {
            productJsonFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", productJsonFile);
            categoryJsonFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", categoryJsonFile);
        }

        public IEnumerable<ProductModel> GetProducts()
        {
            return JsonConvert.DeserializeObject<IEnumerable<ProductModel>>(System.IO.File.ReadAllText(@productJsonFile));
        }

        public IEnumerable<CategoryModel> GetCategories()
        {
            return JsonConvert.DeserializeObject<IEnumerable<CategoryModel>>(System.IO.File.ReadAllText(categoryJsonFile));
        }

        public void SaveProduct(IEnumerable<ProductModel> products)
        {
            System.IO.File.WriteAllText(productJsonFile, JsonConvert.SerializeObject(products));
        }
    }
}
