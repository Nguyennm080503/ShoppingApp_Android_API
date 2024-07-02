using BussinessObject;

namespace DAO
{
    public class CategoryDao : BaseDAO<Category>
    {
        private static CategoryDao instance = null;
        private static readonly object instacelock = new object();

        private CategoryDao()
        {

        }

        public static CategoryDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CategoryDao();
                }
                return instance;
            }
        }
    }
}
