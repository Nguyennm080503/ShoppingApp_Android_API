﻿using BussinessObject;
using DTOS.Account;

namespace Repository
{
    public interface IAccountRepository
    {
        Task AddAccount(NewAccountParam newAccountParam);
        Task UpdateAccountStatus(int accountId, int newStatus);
        Task UpdatePassword(int accountId, string password);
        Task<Account> GetAccountIDLogin(string username, string password);
        Task<IEnumerable<Account>> GetAllAccount();
        Task<Account> GetAccountByID(int accountId);
        Task<Account> GetUsernameExisted(string username);
    }
}
