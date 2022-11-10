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

        public async Task<bool> AddNewAccount(AccountDatum account)
        {
            return await _repository.AddNewAccount(account);
        }

        public async Task<AccountDatum> GetAccountById(int accountId)
        {
            return await _repository.GetAccountById(accountId);
        }
    }
}
