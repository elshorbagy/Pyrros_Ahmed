using Repository.Models;

namespace Service.AccountService
{
    public interface IAccountService
    {
        Task<AccountDatum> GetAccountByIdAsync(int accountId);
        Task<bool> AddNewAccountAsync (AccountDatum account);
    }
}
