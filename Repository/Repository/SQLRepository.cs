using Microsoft.EntityFrameworkCore;
using Repository.DatabaseContext;
using Repository.Models;

namespace Repository.SQLRepository
{
    public class SQLRepository : ISQLRepository
    {
        readonly SQLDBContext _sqlDBContext;

        public SQLRepository(SQLDBContext sqlDBContext)
        {
            _sqlDBContext = sqlDBContext;
        }

        public async Task<bool> AddNewAccountAsync(AccountDatum account)
        {
            await _sqlDBContext.AddAsync(account);
            var affectedRecord = _sqlDBContext.SaveChanges();
            return affectedRecord > 0;
        }

        public async Task<AccountDatum> GetAccountByIdAsync(int accountId)
        {
            var data = await _sqlDBContext
                .Set<AccountDatum>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == accountId);

            data ??= new AccountDatum();

            return data;
        }
    }
}
