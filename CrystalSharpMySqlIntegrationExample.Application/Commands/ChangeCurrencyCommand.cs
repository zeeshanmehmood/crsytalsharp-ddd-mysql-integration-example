using System;
using CrystalSharp.Application;
using CrystalSharpMySqlIntegrationExample.Application.Responses;

namespace CrystalSharpMySqlIntegrationExample.Application.Commands
{
    public class ChangeCurrencyCommand : ICommand<CommandExecutionResult<CurrencyResponse>>
    {
        public Guid GlobalUId { get; set; }
        public string Name { get; set; }
    }
}
