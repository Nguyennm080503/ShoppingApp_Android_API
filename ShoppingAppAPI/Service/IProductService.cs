using BussinessObject;
using DTOS.Product;


namespace Service
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetProductID(int id);
        Task<Product> GetProductIsExisted(string productName);
        Task<IEnumerable<Product>> GetProductByCategoryID(int id);
        Task CreateNewProduct(ProductParam productParam);
    }
}
