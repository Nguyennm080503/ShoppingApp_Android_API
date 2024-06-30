using BussinessObject;
using DTOS.Cart;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Service;
using ShoppingAppAPI.MessageStatusResponse;

namespace ShoppingAppAPI.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController : Controller
    {
        private readonly ICartService cartService;
        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddCart(NewCart newCart)
        {
            try
            {
                await cartService.AddCart(newCart);
                return Ok();
            }catch (Exception ex)
            {
                return BadRequest(new ApiResponseStatus(400, "Have some error when excute function!"));
            }
        }

        [HttpPost("delete/{orderID}")]
        public async Task<IActionResult> DeleteCart(int orderID)
        {
            try
            {
                await cartService.DeleteCart(orderID);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseStatus(400, "Have some error when excute function!"));
            }
        }

        [HttpGet("all/account/{accountID}")]
        public async Task<IActionResult> GetAllCartByAccount(int accountID)
        {
            var cart = await cartService.GetAllCartByAccount(accountID);
            return Ok(cart);
        }


        [HttpGet("order/{orderID}")]
        public async Task<IActionResult> GetCartByOrderID(int orderID)
        {
            var cart = await cartService.GetCartByOrderID(orderID);
            return Ok(cart);
        }

        [HttpGet("new")]
        public async Task<IActionResult> GetCartNewOrderID()
        {
            var cart = await cartService.GetCartNewOrderID();
            return Ok(cart);
        }

        [HttpGet("pending/account/{accountID}")]
        public async Task<IActionResult> GetCartPendingByOrderID(int accountID)
        {
            var cart = await cartService.GetCartPendingByOrderID(accountID);
            if(cart == null)
            {
                return NotFound("Cart not found.");
            }
            return Ok(cart);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateStatusCart(StatusCart statusCart)
        {
            try
            {
                await cartService.UpdateStatusCart(statusCart);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseStatus(400, "Have some error when excute function!"));
            }
        }

        [HttpPost("checkout")]
        public async Task<IActionResult> UpdateStatusCartFinal(UpdateStatusCart statusCart)
        {
            try
            {
                await cartService.UpdateStatusCartFinal(statusCart);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseStatus(400, "Have some error when excute function!"));
            }
        }

        [HttpPost("update/total")]
        public async Task<IActionResult> UpdateTotalCart(UpdateTotalCart updateTotalCart)
        {
            try
            {
                await cartService.UpdateTotalCart(updateTotalCart);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseStatus(400, "Have some error when excute function!"));
            }
        }
    }
}
