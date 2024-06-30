using BussinessObject;
using DTOS.CartDetail;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CartDetailService : ICartDetailService
    {
        private readonly ICartDetailRepository cartDetailRepository;
        public CartDetailService(ICartDetailRepository cartDetailRepository)
        {
            this.cartDetailRepository = cartDetailRepository;
        }
        public async Task AddCartDetail(AddCartDetail cartDetail)
        {
            await cartDetailRepository.AddCartDetail(cartDetail);
        }

        public async Task DeleteCartDetail(DeleteCart delete)
        {
            await cartDetailRepository.DeleteCartDetail(delete);
        }

        public async Task<IEnumerable<CartDetail>> GetAllCartDetailByOrder(int orderID)
        {
            return await cartDetailRepository.GetAllCartDetailByOrder(orderID);
        }

        public async Task<CartDetail> GetCartDetailItemStatus(int orderId, int productId)
        {
            return await cartDetailRepository.GetCartDetailItemStatus(orderId, productId);
        }

        public async Task<double> SumTotalPriceInOrder(int orderId)
        {
            return await cartDetailRepository.SumTotalPriceInOrder(orderId);
        }

        public async Task UpdateQuantityReOrder(UpdateQuantity updateQuantity)
        {
            await cartDetailRepository.UpdateQuantityReOrder(updateQuantity);
        }
    }
}
