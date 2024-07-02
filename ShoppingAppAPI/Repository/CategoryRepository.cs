using BussinessObject;
using DAO;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            return await CategoryDao.Instance.GetAllAsync();
        }
    }
}
