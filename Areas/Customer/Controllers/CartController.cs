using Easy.Commerce.Areas.Customer.Models;
using Easy.Commerce.Areas.Customer.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Easy.Commerce.Areas.Customer.Controllers
{
    public class CartController : BaseCustomerController
    {
        private readonly CustomerService customerService;
        public CartController()
        {
            customerService = new CustomerService();

        }
        public IActionResult Index()
        {
            var cart = customerService.GetCartItems();
            return View(cart);
        }

        public IActionResult Add2Cart(int productId)
        {
            var products = customerService.GetProducts();
            if (products.Any(x => x.ProductID == productId))
            {
                
                var cart = customerService.GetCartItems().ToList();
                if (cart.Any(c => c.ProductID == productId))
                {
                    var addedCartProduct = cart.First(x => x.ProductID == productId);
                    addedCartProduct.Quantity++;
                }
                else
                {
                    var addedProduct = products.First(x => x.ProductID == productId);
                    cart.Add(new CartModel()
                    {
                        CartID = cart.Count + 1,
                        ProductID = addedProduct.ProductID,
                        Code = addedProduct.Code,
                        Name = addedProduct.Name,
                        Quantity = 1
                    });
                }
                customerService.SaveCart(cart);
            }
            return RedirectToAction("Index", "Product", new { a2c = productId });
        }
    }
}