using BussinessObject;
using DTOS.Cart;
using DTOS.CartDetail;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Service;
using ShoppingAppAPI.MessageStatusResponse;

namespace ShoppingAppAPI.Controllers
{
    [ApiController]
    [Route("api/cartdetail/")]
    public class CartDetailController : Controller
    {
        private readonly ICartDetailService cartDetailService;
        public CartDetailController(ICartDetailService cartDetailService)
        {
            this.cartDetailService = cartDetailService;
        }


        [HttpPost("create")]
        public async Task<IActionResult> AddCartDetail(AddCartDetail cartDetail)
        {
            try
            {
                await cartDetailService.AddCartDetail(cartDetail);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseStatus(400, "Have some error when excute function!"));
            }
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteCartDetail(DeleteCart delete)
        {
            try
            {
                await cartDetailService.DeleteCartDetail(delete);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseStatus(400, "Have some error when excute function!"));
            }
        }

        [HttpGet("all/{orderID}")]
        public async Task<IActionResult> GetAllCartDetailByOrder(int orderID)
        {
            var cartdetail = await cartDetailService.GetAllCartDetailByOrder(orderID);
            return Ok(cartdetail);
        }

        [HttpGet("all/{orderID}/detail/{productId}")]
        public async Task<IActionResult> GetCartDetailItemStatus(int orderId, int productId)
        {
            var cartdetail = await cartDetailService.GetCartDetailItemStatus(orderId, productId);
            return Ok(cartdetail);
        }

        [HttpGet("all/{orderID}/sum")]
        public async Task<IActionResult> sumTotalPriceInOrder(int orderId)
        {
            var sum = await cartDetailService.SumTotalPriceInOrder(orderId);
            return Ok(sum);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateQuantityReOrder(UpdateQuantity updateQuantity)
        {
            try
            {
                await cartDetailService.UpdateQuantityReOrder(updateQuantity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseStatus(400, "Have some error when excute function!"));
            }
        }
    }
}
