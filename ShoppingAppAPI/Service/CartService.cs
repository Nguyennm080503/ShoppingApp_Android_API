using BussinessObject;
using DTOS.Cart;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CartService : ICartService
    {
        private readonly ICartRepository cartRepository;
        public CartService(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }
        public async Task AddCart(NewCart newCart)
        {
            await cartRepository.AddCart(newCart);
        }

        public async Task DeleteCart(int orderID)
        {
            await cartRepository.DeleteCart(orderID);
        }

        public async Task<IEnumerable<Cart>> GetAllCartByAccount(int accountID)
        {
           return await cartRepository.GetAllCartByAccount(accountID);
        }

        public async Task<Cart> GetCartByOrderID(int orderID)
        {
            return await cartRepository.GetCartByOrderID(orderID);
        }

        public async Task<Cart> GetCartNewOrderID()
        {
            return await cartRepository.GetCartNewOrderID();
        }

        public async Task<Cart> GetCartPendingByOrderID(int accountID)
        {
            return await cartRepository.GetCartPendingByOrderID(accountID);
        }

        public async Task UpdateStatusCart(StatusCart statusCart)
        {
            await cartRepository.UpdateStatusCart(statusCart);
        }

        public async Task UpdateStatusCartFinal(UpdateStatusCart statusCart)
        {
            await cartRepository.UpdateStatusCartFinal(statusCart);
        }

        public async Task UpdateTotalCart(UpdateTotalCart updateTotalCart)
        {
            await cartRepository.UpdateTotalCart(updateTotalCart);
        }
    }
}
