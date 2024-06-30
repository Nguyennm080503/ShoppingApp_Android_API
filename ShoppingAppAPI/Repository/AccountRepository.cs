using BussinessObject;
using DAO;
using DTOS.Account;

namespace Repository
{
    public class AccountRepository : IAccountRepository
    {
        public async Task AddAccount(NewAccountParam newAccountParam)
        {
            Account account = new Account()
            {
                Name = newAccountParam.Name,
                Email = newAccountParam.Email,
                Phone = newAccountParam.Phone,
                Username = newAccountParam.Username,
                Password = newAccountParam.Password,
                RoleID = 1,
                Status = 0
            };
            await AccountDao.Instance.CreateAsync(account);
        }

        public async Task<Account> GetAccountByID(int accountId)
        {
            return await AccountDao.Instance.GetAccountById(accountId);
        }

        public async Task<Account> GetAccountIDLogin(string username, string password)
        {
            return await AccountDao.Instance.GetAccountLogin(username, password);
        }

        public async Task<IEnumerable<Account>> GetAllAccount()
        {
            return await AccountDao.Instance.GetAllAsync();
        }

        public async Task<Account> GetUsernameExisted(string username)
        {
            return await AccountDao.Instance.GetUsernameExisted(username);
        }

        public async Task UpdateAccountStatus(int accountId, int newStatus)
        {
            Account account = await AccountDao.Instance.GetAccountById(accountId);
            account.Status = newStatus;
            await AccountDao.Instance.UpdateAsync(account);
        }

        public async Task UpdatePassword(int accountId, string password)
        {
            Account account = await AccountDao.Instance.GetAccountById(accountId);
            account.Password = password;
            await AccountDao.Instance.UpdateAsync(account);
        }
    }
}
