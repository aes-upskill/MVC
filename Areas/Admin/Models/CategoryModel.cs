using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Easy.Commerce.Areas.Admin.Models
{
    [Table("Categories")]
    public class CategoryModel
    {
        [Key]
        public int CategoryID { get; set; }
        public string Name { get; set; }
    }
}
