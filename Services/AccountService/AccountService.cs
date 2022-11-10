using Repository.Models;
using Repository.SQLRepository;

namespace Service.AccountService
{
    public class AccountService : IAccountService
    {
        readonly ISQLRepository _repository;

        public AccountService(ISQLRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddNewAccountAsync(AccountDatum account)
        {
            return await _repository.AddNewAccountAsync(account);
        }

        public async Task<AccountDatum> GetAccountByIdAsync(int accountId)
        {
            return await _repository.GetAccountByIdAsync(accountId);
        }
    }
}
