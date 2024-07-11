using BussinessObject;
using Microsoft.EntityFrameworkCore;


namespace DAO
{
    public class ProductDao : BaseDAO<Product>
    {
        private static ProductDao instance = null;
        private static readonly object instacelock = new object();

        private ProductDao()
        {

        }

        public static ProductDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProductDao();
                }
                return instance;
            }
        }

        public override async Task<IEnumerable<Product>> GetAllAsync()
        {
            var context = new ShoppingAppDBContext();
            return await context.Product.Include(x => x.Category).Where(x => x.Status == 0).OrderByDescending(x => x.ProductID).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductAsync()
        {
            var context = new ShoppingAppDBContext();
            return await context.Product.Include(x => x.Category).OrderByDescending(x => x.ProductID).ToListAsync();
        }


        public async Task<Product> GetProductID(int id)
        {
            var context = new ShoppingAppDBContext();
            return await context.Product.Include(x => x.Category).FirstOrDefaultAsync(x => x.ProductID.Equals(id));
        }

        public async Task<Product> GetProductIsExisted(string productName)
        {
            var context = new ShoppingAppDBContext();
            return await context.Product
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Name.Equals(productName));
        }

        public async Task<IEnumerable<Product>> GetProductByCategoryID(int id)
        {
            var context = new ShoppingAppDBContext();
            return await context.Product.Include(x => x.Category).Where(x => x.Status == 0 && x.CategoryID == id).OrderByDescending(x => x.ProductID).ToListAsync();
        }

        public async Task<bool> UpdateProductAsycn(Product product)
        {
            try
            {
                using (var _context = new ShoppingAppDBContext())
                {
                    _context.Entry(product).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                Console.WriteLine($"Error updating entity: {ex.Message}");
                return false;
            }
        }
    }
}
