namespace DTOS.Product
{
    public class ProductUpdateParam
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public int TypeID { get; set; }
        public int Status { get; set; }
    }
}
