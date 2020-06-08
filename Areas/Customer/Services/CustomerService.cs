using Easy.Commerce.Areas.Customer.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Easy.Commerce.Areas.Customer.Services
{
    public class CustomerService
    {
        private readonly string productJsonFile = "products.json";
        private readonly string categoryJsonFile = "categories.json";
        private readonly string cartJsonFile = "cart.json";

        public CustomerService()
        {
            productJsonFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", productJsonFile);
            categoryJsonFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", categoryJsonFile);
            cartJsonFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", cartJsonFile);

        }

        public IEnumerable<ProductModel> GetProducts()
        {
            return JsonConvert.DeserializeObject<IEnumerable<ProductModel>>(System.IO.File.ReadAllText(productJsonFile));
        }

        public IEnumerable<CategoryModel> GetCategories()
        {
            return JsonConvert.DeserializeObject<IEnumerable<CategoryModel>>(System.IO.File.ReadAllText(categoryJsonFile));
        }

        public void SaveProduct(IEnumerable<ProductModel> products)
        {
            System.IO.File.WriteAllText(productJsonFile, JsonConvert.SerializeObject(products));
        }

        public IEnumerable<CartModel> GetCartItems()
        {
            return JsonConvert.DeserializeObject<IEnumerable<CartModel>>(System.IO.File.ReadAllText(cartJsonFile)) ?? Enumerable.Empty<CartModel>();
        }

        public void SaveCart(IEnumerable<CartModel> cart)
        {
            System.IO.File.WriteAllText(cartJsonFile, JsonConvert.SerializeObject(cart));
        }
    }
}
