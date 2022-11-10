using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.DatabaseContext;
using Repository.SQLRepository;
using Function;
using System.IO;
using Service.AccountService;

[assembly: FunctionsStartup(typeof(Startup))]
namespace Function
{
    public class Startup : FunctionsStartup
    {
        private IConfigurationRoot _configurationRoot;

        public override void Configure(IFunctionsHostBuilder builder)
        {
            var context = builder.GetContext();

            builder.Services.AddScoped<ISQLRepository, SQLRepository>();
            builder.Services.AddScoped<IAccountService, AccountService>();

            _configurationRoot ??= new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(context.ApplicationRootPath, "application.settings.json"), optional: true, reloadOnChange: true)
                .Build();

            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<SQLDBContext>(options =>
                    options.UseSqlServer(_configurationRoot.GetConnectionString("DB")));
        }
    }
}
