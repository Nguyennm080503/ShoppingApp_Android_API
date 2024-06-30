using BussinessObject;
using DTOS.CartDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ICartDetailRepository
    {
        Task<IEnumerable<CartDetail>> GetAllCartDetailByOrder(int orderID);
        Task<CartDetail> GetCartDetailItemStatus(int orderId, int productId);
        Task<double> SumTotalPriceInOrder(int orderId);
        Task DeleteCartDetail(DeleteCart delete);
        Task UpdateQuantityReOrder(UpdateQuantity updateQuantity);
        Task AddCartDetail(AddCartDetail cartDetail);
    }
}
