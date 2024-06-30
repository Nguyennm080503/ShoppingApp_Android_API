using BussinessObject;
using DAO;
using DTOS.Cart;
using DTOS.Enum;

namespace Repository
{
    public class CartRepository : ICartRepository
    {
        public async Task AddCart(NewCart newCart)
        {
            Cart cart = new Cart()
            {
                AccountID = newCart.AccountID,
                Addresss = "",
                DateOrder = DateTime.Now,
                TotalBill = newCart.TotalBill,
                Status = 0
            };
            await CartDao.Instance.CreateAsync(cart);
        }

        public async Task DeleteCart(int orderID)
        {
            var cart = await CartDao.Instance.GetCartByOrderID(orderID);
            await CartDao.Instance.RemoveAsync(cart);
        }

        public async Task<IEnumerable<Cart>> GetAllCartByAccount(int accountID)
        {
            return await CartDao.Instance.GetAllCartByAccount(accountID);
        }

        public async Task<Cart> GetCartByOrderID(int orderID)
        {
            return await CartDao.Instance.GetCartByOrderID(orderID);
        }

        public async Task<Cart> GetCartNewOrderID()
        {
            return await CartDao.Instance.GetCartNewOrderID();
        }

        public async Task<Cart> GetCartPendingByOrderID(int accountID)
        {
            return await CartDao.Instance.GetCartPendingByOrderID(accountID);
        }

        public async Task UpdateStatusCartFinal(UpdateStatusCart statusCart)
        {
            var cart = await CartDao.Instance.GetCartByOrderID(statusCart.CartID);
            cart.Addresss = statusCart.Addresss;
            cart.DateOrder = DateTime.Now;
            cart.Status = (int)CartEnum.ORDER_SUCCESS;
            await CartDao.Instance.UpdateAsync(cart);
        }

        public async Task UpdateStatusCart(StatusCart statusCart)
        {
            var cart = await CartDao.Instance.GetCartByOrderID(statusCart.CartID);
            cart.Status = statusCart.Status;
            await CartDao.Instance.UpdateAsync(cart);
        }

        public async Task UpdateTotalCart(UpdateTotalCart updateTotalCart)
        {
            var cart = await CartDao.Instance.GetCartPendingByOrderID(updateTotalCart.AccountID);
            cart.TotalBill = updateTotalCart.TotalBill;
            await CartDao.Instance.UpdateAsync(cart);
        }
    }
}
