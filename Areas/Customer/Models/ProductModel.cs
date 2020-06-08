using System;

namespace Easy.Commerce.Areas.Customer.Models
{
    public class ProductModel
    {
        public int ProductID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int CategoryID { get; set; }
        public CategoryModel Category { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
