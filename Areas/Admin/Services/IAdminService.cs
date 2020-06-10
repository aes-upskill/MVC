using Easy.Commerce.Areas.Admin.Models;
using System.Collections.Generic;

namespace Easy.Commerce.Areas.Admin.Services
{
    public interface IAdminService
    {
        ProductModel GetProductById(int productID);
        IList<ProductModel> GetProducts();
        IList<CategoryModel> GetCategories();
        void SaveProduct(ProductModel product);
        void BulkUpdateProducts();

    }
}
