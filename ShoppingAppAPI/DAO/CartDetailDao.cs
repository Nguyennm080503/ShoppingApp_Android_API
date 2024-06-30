using BussinessObject;
using DTOS.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class CartDetailDao : BaseDAO<CartDetail>
    {
        private static CartDetailDao instance = null;
        private static readonly object instacelock = new object();

        private CartDetailDao()
        {

        }

        public static CartDetailDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CartDetailDao();
                }
                return instance;
            }
        }

        public async Task<IEnumerable<CartDetail>> GetAllCartDetailByOrder(int orderID)
        {
            var context = new ShoppingAppDBContext();
            return await context.CartDetail.Where(x => x.CartID == orderID).ToListAsync();
        }



        public async Task<CartDetail> GetCartDetailItemStatus(int orderId, int productId)
        {
            var context = new ShoppingAppDBContext();
            return await context.CartDetail.FirstOrDefaultAsync(x => x.CartID == orderId && x.ProductID == productId);
        }

        public async Task<double> SumTotalPriceInOrder(int orderId)
        {
            var context = new ShoppingAppDBContext();
            return await context.CartDetail.Where(x => x.CartID == orderId).SumAsync(x => x.UnitPrice);
        }

    }
}
