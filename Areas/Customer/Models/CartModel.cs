namespace Easy.Commerce.Areas.Customer.Models
{
    public class CartModel
    {
        public int CartID { get; set; }
        public int ProductID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}