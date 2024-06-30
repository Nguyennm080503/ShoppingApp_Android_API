using BussinessObject;
using DTOS.Product;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task CreateNewProduct(ProductParam productParam)
        {
            await productRepository.CreateNewProduct(productParam);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await productRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductAsync()
        {
            return await productRepository.GetAllProductAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategoryID(int id)
        {
            return await productRepository.GetProductByCategoryID(id);
        }

        public async Task<Product> GetProductID(int id)
        {
            return await productRepository.GetProductID(id);
        }

        public async Task<Product> GetProductIsExisted(string productName)
        {
            return await productRepository.GetProductIsExisted(productName);
        }

        public async Task UpdateProduct(ProductUpdateParam productParam)
        {
            await productRepository.UpdateProduct(productParam);
        }
    }
}
