using BussinessObject;
using DTOS.Account;
using DTOS.Product;
using Microsoft.AspNetCore.Mvc;
using Service;
using ShoppingAppAPI.MessageStatusResponse;
using System.Collections.Generic;

namespace ShoppingAppAPI.Controllers
{
    [ApiController]
    [Route("api/product/")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateNewProduct(ProductParam productParam)
        {

            try
            {
                var product = await productService.GetProductIsExisted(productParam.Name);
                if (product == null)
                {
                    // Decode the Base64 string to byte array
                    //productParam.Image = Convert.FromBase64String(productParam.ImageBase64);

                    await productService.CreateNewProduct(productParam);
                    return Ok();
                }
                return BadRequest(new ApiResponseStatus(400, "Product name is existed!"));

            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseStatus(400, "Have some error when excute function!"));
            }
        }

        [HttpGet("all/active")]
        public async Task<IActionResult> GetAllProductActive()
        {
            var products = await productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllProduct()
        {
            try
            {
                var products = await productService.GetAllProductAsync();
                return Ok(products);
            }catch(Exception ex)
            {
                return BadRequest(new ApiResponseStatus(400, "Have some error when excute function!"));
            }
            
        }

        [HttpGet("detail/{id}")]
        public async Task<IActionResult> GetProductByID(int id)
        {
            var product = await productService.GetProductID(id);
            return Ok(product);
        }

        [HttpGet("all/cate/{id}")]
        public async Task<IActionResult> GetAllProductActiveByCategory(int id)
        {
            var products = await productService.GetProductByCategoryID(id);
            return Ok(products);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateProduct(ProductUpdateParam productParam)
        {
            try
            {
                var product = await productService.GetProductID(productParam.ProductID);
                if (product == null)
                {
                    return BadRequest(new ApiResponseStatus(400, "Product is not existed!"));
                }
                await productService.UpdateProduct(productParam);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseStatus(400, "Have some error when excute function!"));
            }
        }
    }
}
