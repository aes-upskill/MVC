using Easy.Commerce.Areas.Customer.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Easy.Commerce.Areas.Customer.Controllers
{
    public class ProductController : BaseCustomerController
    {
        private readonly CustomerService customerService;
        public ProductController()
        {
            customerService = new CustomerService();
        }

        public IActionResult Index()
        {
            var products = customerService.GetProducts();
            var categories = customerService.GetCategories();
            foreach (var product in products)
            {
                product.Category = categories.FirstOrDefault(p => p.CategoryID == product.CategoryID);
            }
            return View(products);
        }

    }
}