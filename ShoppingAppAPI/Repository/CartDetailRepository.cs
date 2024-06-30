using BussinessObject;
using DAO;
using DTOS.CartDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CartDetailRepository : ICartDetailRepository
    {
        public async Task AddCartDetail(AddCartDetail cartDetail)
        {
            CartDetail cartDetail1 = new CartDetail()
            {
                CartID = cartDetail.CartID,
                ProductID = cartDetail.ProductID,
                Quantity = cartDetail.Quantity,
                UnitPrice = cartDetail.UnitPrice,
            };
            await CartDetailDao.Instance.CreateAsync(cartDetail1);
        }

        public async Task DeleteCartDetail(DeleteCart delete)
        {
            var cartdetail = await CartDetailDao.Instance.GetCartDetailItemStatus(delete.CartID, delete.ProductID);
            await CartDetailDao.Instance.RemoveAsync(cartdetail);
        }

        public async Task<IEnumerable<CartDetail>> GetAllCartDetailByOrder(int orderID)
        {
            return await CartDetailDao.Instance.GetAllCartDetailByOrder(orderID);
        }

        public async Task<CartDetail> GetCartDetailItemStatus(int orderId, int productId)
        {
            return await CartDetailDao.Instance.GetCartDetailItemStatus(orderId, productId);
        }

        public async Task<double> SumTotalPriceInOrder(int orderId)
        {
            return await CartDetailDao.Instance.SumTotalPriceInOrder(orderId);
        }

        public async Task UpdateQuantityReOrder(UpdateQuantity updateQuantity)
        {
            var cartdetail = await CartDetailDao.Instance.GetCartDetailItemStatus(updateQuantity.CartID, updateQuantity.ProductID);
            cartdetail.Quantity = updateQuantity.Quantity;
            cartdetail.UnitPrice = updateQuantity.UnitPrice;
            await CartDetailDao.Instance.UpdateAsync(cartdetail);
        }
    }
}
