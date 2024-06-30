using BussinessObject;
using DTOS.Enum;
using Microsoft.EntityFrameworkCore;

namespace DAO
{
    public class CartDao : BaseDAO<Cart>
    {
        private static CartDao instance = null;
        private static readonly object instacelock = new object();

        private CartDao()
        {

        }

        public static CartDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CartDao();
                }
                return instance;
            }
        }

        public async Task<IEnumerable<Cart>> GetAllCartByAccount(int accountID) 
        { 
            var context = new ShoppingAppDBContext();
            return await context.Cart.Where(x => x.AccountID == accountID && x.Status != (int)CartEnum.PENDING).OrderByDescending(x => x.CartID).ToListAsync();
        }



        public async Task<Cart> GetCartNewOrderID()
        {
            var context = new ShoppingAppDBContext();
            return await context.Cart.OrderByDescending(x => x.CartID).FirstOrDefaultAsync();
        }

        public async Task<Cart> GetCartByOrderID(int orderID)
        {
            var context = new ShoppingAppDBContext();
            return await context.Cart.FirstOrDefaultAsync(x => x.CartID.Equals(orderID));
        }

        public async Task<Cart> GetCartPendingByOrderID(int accountID)
        {
            var context = new ShoppingAppDBContext();
            return await context.Cart.FirstOrDefaultAsync(x => x.AccountID.Equals(accountID) && x.Status == (int)CartEnum.PENDING);
        }
    }
}
