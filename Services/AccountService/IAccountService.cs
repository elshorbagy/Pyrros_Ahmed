using Repository.Models;

namespace Service.AccountService
{
    public interface IAccountService
    {
        Task<AccountDatum> GetAccountById(int accountId);
        Task<bool> AddNewAccount (AccountDatum account);
    }
}
