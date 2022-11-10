using Repository.Models;

namespace Repository.SQLRepository
{
    public interface ISQLRepository
    {
        Task<AccountDatum> GetAccountById(int accountId);
        Task<bool> AddNewAccount (AccountDatum account);
    }
}
