using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Easy.Commerce.Areas.Admin.Models
{
    [Table("Products")]
    public class ProductModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        [DisplayName("Product Code")]
        public string Code { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Product Name")]
        [Column("ProductName")]
        public string Name { get; set; }

        [DisplayName("Product Category")]
        public int CategoryID { get; set; }

        public CategoryModel Category { get; set; }

        public DateTime ModifiedDate { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}