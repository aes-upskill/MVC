using Easy.Commerce.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace Easy.Commerce.Areas.Admin.Data
{
    public class AdminDBContext : DbContext
    {
        public AdminDBContext(DbContextOptions<AdminDBContext> options) :
            base(options)
        {

        }

        public DbSet<ProductModel> Products { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
    }
}
