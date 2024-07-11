using BussinessObject;
using DTOS.Product;
using Repository;
using System;
using System.Collections;
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

        public async Task<IEnumerable<ProductView>> GetAllAsync()
        {
            List<ProductView> productViews = new List<ProductView>();

            var products = await productRepository.GetAllAsync(); ;

            foreach (var product in products)
            {
                ProductView item = new ProductView()
                {
                    CategoryID = product.CategoryID,
                    CategoryName = product.Category.Name,
                    Name = product.Name,
                    Price = product.Price,
                    ProductID = product.ProductID,
                    Status = product.Status,
                    Description = product.Description,
                    Image = Convert.ToBase64String(product.Image),
                };

                productViews.Add(item);
            }

            return productViews;
        }

        public async Task<IEnumerable<ProductView>> GetAllProductAsync()
        {
            List<ProductView> productViews = new List<ProductView>();

            var products = await productRepository.GetAllProductAsync();

            foreach (var product in products)
            {
                ProductView item = new ProductView()
                {
                    CategoryID = product.CategoryID,
                    CategoryName = product.Category.Name,
                    Name = product.Name,
                    Price = product.Price,
                    ProductID = product.ProductID,
                    Status = product.Status,
                    Description = product.Description,
                    Image = Convert.ToBase64String(product.Image),
                };

                productViews.Add(item);
            }

            return productViews;
        }

        public async Task<IEnumerable<ProductView>> GetProductByCategoryID(int id)
        {
            List<ProductView> productViews = new List<ProductView>();

            var products = await productRepository.GetProductByCategoryID(id);

            foreach (var product in products)
            {
                ProductView item = new ProductView()
                {
                    CategoryID = product.CategoryID,
                    CategoryName = product.Category.Name,
                    Name = product.Name,
                    Price = product.Price,
                    ProductID = product.ProductID,
                    Status = product.Status,
                    Description = product.Description,
                    Image = Convert.ToBase64String(product.Image),
                };

                productViews.Add(item);
            }

            return productViews;
        }

        public async Task<ProductView> GetProductID(int id)
        {
            var product = await productRepository.GetProductID(id);
            ProductView item = new ProductView()
            {
                CategoryID = product.CategoryID,
                CategoryName = product.Category.Name,
                Name = product.Name,
                Price = product.Price,
                ProductID = product.ProductID,
                Status = product.Status,
                Description = product.Description,
                Image = Convert.ToBase64String(product.Image),
            };
            return item;
        }

        public async Task<ProductView> GetProductIsExisted(string productName)
        {
            var product = await productRepository.GetProductIsExisted(productName);
            if(product != null)
            {
                ProductView item = new ProductView()
                {
                    CategoryID = product.CategoryID,
                    CategoryName = product.Category.Name,
                    Name = product.Name,
                    Price = product.Price,
                    ProductID = product.ProductID,
                    Status = product.Status,
                    Description = product.Description,
                    Image = Convert.ToBase64String(product.Image),
                };
                return item;
            }
            return null;
            
        }

        public async Task UpdateProduct(ProductUpdateParam productParam)
        {
            await productRepository.UpdateProduct(productParam);
        }
    }
}
