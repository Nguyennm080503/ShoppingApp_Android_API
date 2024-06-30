using BussinessObject;
using Microsoft.EntityFrameworkCore;

namespace DAO
{
    public class AccountDao: BaseDAO<Account>
    {
        private static AccountDao instance = null;
        private static readonly object instacelock = new object();

        private AccountDao()
        {

        }

        public static AccountDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountDao();
                }
                return instance;
            }
        }

        public override async Task<IEnumerable<Account>> GetAllAsync()
        {
            var context = new ShoppingAppDBContext();
            return await context.Account.Where(x => x.RoleID != 0).OrderByDescending(x => x.AccountID).ToListAsync();
        }



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
