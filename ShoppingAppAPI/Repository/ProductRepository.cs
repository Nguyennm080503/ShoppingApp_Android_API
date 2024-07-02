using BussinessObject;
using DAO;
using DTOS.Product;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        public async Task CreateNewProduct(ProductParam productParam)
        {
            Product product = new Product()
            {
                CategoryID = productParam.CategoryID,
                Description = productParam.Description,
                Name = productParam.Name,
                Image = productParam.Image,
                Price = productParam.Price,
                Status = 0
            };
            await ProductDao.Instance.CreateAsync(product);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await ProductDao.Instance.GetAllAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductAsync()
        {
            return await ProductDao.Instance.GetAllProductAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategoryID(int id)
        {
            return await ProductDao.Instance.GetProductByCategoryID(id);
        }

        public async Task<Product> GetProductID(int id)
        {
            return await ProductDao.Instance.GetProductID(id);
        }

        public async Task<Product> GetProductIsExisted(string productName)
        {
            return await ProductDao.Instance.GetProductIsExisted(productName);
        }

        public async Task UpdateProduct(ProductUpdateParam productParam)
        {
            Product product = await ProductDao.Instance.GetProductID(productParam.ProductID);
            product.Name = productParam.Name;
            product.Price = productParam.Price;
            product.Description = productParam.Description;
            product.CategoryID = productParam.TypeID;
            product.Status = productParam.Status;
            product.Image = productParam.Image;


            await ProductDao.Instance.UpdateProductAsycn(product);
        }
    }
}
