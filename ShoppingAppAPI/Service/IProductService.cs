using BussinessObject;
using DTOS.Product;


namespace Service
{
    public interface IProductService
    {
        Task<IEnumerable<ProductView>> GetAllAsync();
        Task<IEnumerable<ProductView>> GetAllProductAsync();
        Task<ProductView> GetProductID(int id);
        Task<ProductView> GetProductIsExisted(string productName);
        Task<IEnumerable<ProductView>> GetProductByCategoryID(int id);
        Task CreateNewProduct(ProductParam productParam);
        Task UpdateProduct(ProductUpdateParam productParam);
    }
}
