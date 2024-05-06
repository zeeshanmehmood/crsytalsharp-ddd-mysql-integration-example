using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CrystalSharp.MySql.Database;
using CrystalSharpMySqlIntegrationExample.Application.Domain.Aggregates.CurrencyAggregate;

namespace CrystalSharpMySqlIntegrationExample.Application.Infrastructure
{
    public class AppDbContext : DbContext
    {
        private readonly IMySqlEntityFrameworkCoreContext _mySqlEfContext;
        public DbSet<Currency> Currency { get; set; }

        public AppDbContext()
        {
            //
        }

        public AppDbContext(DbContextOptions<AppDbContext> options, IMySqlEntityFrameworkCoreContext mySqlEfContext)
            : base(options)
        {
            _mySqlEfContext = mySqlEfContext;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _mySqlEfContext.SaveChanges(this, cancellationToken).ConfigureAwait(false);
        }
    }
}
