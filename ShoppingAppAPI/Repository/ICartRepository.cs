using BussinessObject;
using DTOS.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ICartRepository
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
