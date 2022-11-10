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

        public async Task<bool> AddNewAccount(AccountDatum account)
        {
            await _sqlDBContext.AddAsync(account);
            var affectedRecord = _sqlDBContext.SaveChanges();
            return affectedRecord > 0;
        }

        public async Task<AccountDatum> GetAccountById(int accountId)
        {
            return await _sqlDBContext
                .Set<AccountDatum>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == accountId);
        }
    }
}
