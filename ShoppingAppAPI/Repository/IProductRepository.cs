﻿using BussinessObject;
using DTOS.Product;

namespace Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<IEnumerable<Product>> GetAllProductAsync();
        Task<Product> GetProductID(int id);
        Task<Product> GetProductIsExisted(string productName);
        Task<IEnumerable<Product>> GetProductByCategoryID(int id);
        Task CreateNewProduct(ProductParam productParam);
        Task UpdateProduct(ProductUpdateParam productParam);
    }
}
