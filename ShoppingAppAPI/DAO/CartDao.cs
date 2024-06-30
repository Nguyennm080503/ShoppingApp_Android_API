using BussinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        //public override async Task<IEnumerable<Cart>> GetAllAsync()
        //{
        //    var context = new ShoppingAppDBContext();
        //    return await context.Account.Where(x => x.RoleID != 0).OrderByDescending(x => x.AccountID).ToListAsync();
        //}



        public async Task<Account> GetAccountLogin(string username, string password)
        {
            var context = new ShoppingAppDBContext();
            return await context.Account.FirstOrDefaultAsync(x => x.Username.Equals(username) && x.Password.Equals(password));
        }

        public async Task<Account> GetAccountById(int id)
        {
            var context = new ShoppingAppDBContext();
            return await context.Account.FirstOrDefaultAsync(x => x.AccountID.Equals(id));
        }

        public async Task<Account> GetUsernameExisted(string username)
        {
            var context = new ShoppingAppDBContext();
            return await context.Account.FirstOrDefaultAsync(x => x.Username.Equals(username));
        }
    }
}
