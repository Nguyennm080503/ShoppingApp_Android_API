

namespace BussinessObject
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public int Status { get; set; }

        public IEnumerable<CartDetail> Details { get; set; }

    }
}
