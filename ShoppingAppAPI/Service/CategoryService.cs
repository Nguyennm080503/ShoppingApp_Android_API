using BussinessObject;
using DTOS.Category;
using Repository;

namespace Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public async Task<IEnumerable<CategoryView>> GetAllCategory()
        {
            var category = await categoryRepository.GetAllCategory();
            return category.Select(c => new CategoryView
            {
                CategoryID = c.CategoryID,
                Name = c.Name
            });
        }
    }
}
