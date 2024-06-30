using BussinessObject;
using DTOS.Account;
using Repository;

namespace Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public async Task AddAccount(NewAccountParam newAccountParam)
        {
            await accountRepository.AddAccount(newAccountParam);
        }

        public async Task<Account> GetAccountByID(int accountId)
        {
            return await accountRepository.GetAccountByID(accountId);
        }

        public async Task<Account> GetAccountIDLogin(string username, string password)
        {
            return await accountRepository.GetAccountIDLogin(username, password);
        }

        public async Task<IEnumerable<Account>> GetAllAccount()
        {
            return await accountRepository.GetAllAccount();
        }

        public async Task<Account> GetUsernameExisted(string username)
        {
            return await accountRepository.GetUsernameExisted(username);
        }

        public async Task UpdateAccountStatus(int accountId, int newStatus)
        {
            await accountRepository.UpdateAccountStatus(accountId, newStatus);
        }

        public async Task UpdatePassword(int accountId, string password)
        {
            await accountRepository.UpdatePassword(accountId, password);
        }
    }
}
