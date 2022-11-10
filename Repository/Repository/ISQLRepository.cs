using Repository.Models;

namespace Repository.SQLRepository
{
    public interface ISQLRepository
    {
        Task<AccountDatum> GetAccountByIdAsync(int accountId);
        Task<bool> AddNewAccountAsync (AccountDatum account);
    }
}
