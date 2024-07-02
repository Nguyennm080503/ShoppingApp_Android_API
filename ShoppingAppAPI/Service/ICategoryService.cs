using BussinessObject;
using DTOS.Category;

namespace Service
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryView>> GetAllCategory();
    }
}
