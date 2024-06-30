

namespace BussinessObject
{
    public class CartDetail
    {
        public int CartDetailID { get; set; }
        public int CartID { get; set; }
        public Cart Cart { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
    }
}
