

namespace BussinessObject
{
    public class Cart
    {
        public int CartID { get; set; }
        public int AccountID { get; set; }
        public Account Account { get; set; }
        public double TotalBill { get; set; }
        public DateTime DateOrder { get; set; }
        public string? Addresss { get; set; }
        public int Status { get; set; }

        public IEnumerable<CartDetail> Details { get; set; }
    }
}
