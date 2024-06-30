using BussinessObject;
using DTOS.Cart;

namespace Service
{
    public interface ICartService
    {
        Task<IEnumerable<Cart>> GetAllCartByAccount(int accountID);
        Task<Cart> GetCartNewOrderID();
        Task<Cart> GetCartByOrderID(int orderID);
        Task<Cart> GetCartPendingByOrderID(int accountID);
        Task UpdateTotalCart(UpdateTotalCart updateTotalCart);
        Task UpdateStatusCartFinal(UpdateStatusCart statusCart);
        Task AddCart(NewCart newCart);
        Task DeleteCart(int orderID);
        Task UpdateStatusCart(StatusCart statusCart);
    }
}
