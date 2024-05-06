using CrystalSharp.Application;
using CrystalSharpMySqlIntegrationExample.Application.Responses;

namespace CrystalSharpMySqlIntegrationExample.Application.Commands
{
    public class CreateCurrencyCommand : ICommand<CommandExecutionResult<CurrencyResponse>>
    {
        public string Name { get; set; }
    }
}
