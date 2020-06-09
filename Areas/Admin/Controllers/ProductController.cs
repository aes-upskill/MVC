using Easy.Commerce.Areas.Admin.Models;
using Easy.Commerce.Areas.Admin.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Easy.Commerce.Areas.Admin.Controllers
{
    public class ProductController : BaseAdminController
    {
        private readonly IAdminService adminService;

        public ProductController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        public IActionResult Index()
        {
            var products = adminService.GetProducts();
            return View(products);
        }

        public IActionResult New()
        {
            var categories = adminService.GetCategories();
            ViewBag.Categories = categories.Select(x => new SelectListItem(x.Name, x.CategoryID.ToString()));
            return View("ProductInfo", new ProductModel());
        }

        public IActionResult EditById(int id)
        {
            var products = adminService.GetProducts();
            if (products.Any(x => x.ProductID == id))
            {
                var categories = adminService.GetCategories();
                ViewBag.Categories = categories.Select(x => new SelectListItem(x.Name, x.CategoryID.ToString()));
                return View("ProductInfo", products.First(x => x.ProductID == id));
            }
            return RedirectToActionPermanent("New");
        }

        public IActionResult Save(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                adminService.SaveProduct(product);
            }
            return RedirectToAction("Index", "Product");
        }
    }
}