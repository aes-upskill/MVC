using Easy.Commerce.Areas.Admin.Models;
using System.Collections.Generic;

namespace Easy.Commerce.Areas.Admin.Services
{
    public interface IAdminService
    {
        IList<ProductModel> GetProducts();
        IList<CategoryModel> GetCategories();
        void SaveProduct(ProductModel product);

    }
}
