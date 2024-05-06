using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CrystalSharp.Application;
using CrystalSharp.Application.Handlers;
using CrystalSharp.Domain;
using CrystalSharpMySqlIntegrationExample.Application.Commands;
using CrystalSharpMySqlIntegrationExample.Application.Domain.Aggregates.CurrencyAggregate;
using CrystalSharpMySqlIntegrationExample.Application.Infrastructure;
using CrystalSharpMySqlIntegrationExample.Application.Responses;

namespace CrystalSharpMySqlIntegrationExample.Application.CommandHandlers
{
    public class ChangeCurrencyCommandHandler : CommandHandler<ChangeCurrencyCommand, CurrencyResponse>
    {
        private readonly AppDbContext _dbContext;

        public ChangeCurrencyCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<CommandExecutionResult<CurrencyResponse>> Handle(ChangeCurrencyCommand request, CancellationToken cancellationToken = default)
        {
            if (request == null) return await Fail("Invalid command.");

            Currency existingCurrency = await _dbContext.Currency.SingleOrDefaultAsync(x =>
                x.GlobalUId == request.GlobalUId
                && x.EntityStatus == EntityStatus.Active,
                cancellationToken)
                .ConfigureAwait(false);

            if (existingCurrency == null)
            {
                return await Fail("Currency not found.");
            }

            existingCurrency.ChangeName(request.Name);

            await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            CurrencyResponse response = new() { GlobalUId = existingCurrency.GlobalUId, Name = existingCurrency.Name };

            return await Ok(response);
        }
    }
}
