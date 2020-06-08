using Easy.Commerce.Areas.Admin.Models;
using Easy.Commerce.Areas.Admin.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace Easy.Commerce.Areas.Admin.Controllers
{
    public class ProductController : BaseAdminController
    {
        private readonly AdminService adminService;
        public ProductController()
        {
            adminService = new AdminService();
        }

        public IActionResult Index()
        {
            var products = adminService.GetProducts();
            var categories = adminService.GetCategories();
            foreach (var product in products)
            {
                product.Category = categories.FirstOrDefault(p => p.CategoryID == product.CategoryID);
            }
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
                var products = adminService.GetProducts().ToList();
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
                adminService.SaveProduct(products);
            }
            return RedirectToAction("Index","Product");
        }
    }
}