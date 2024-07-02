using BussinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using ShoppingAppAPI.MessageStatusResponse;

namespace ShoppingAppAPI.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategory()
        {
            try
            {
                var categories = await _categoryService.GetAllCategory();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseStatus(400, "Have some error when excute function!"));
            }
        }
    }
}
