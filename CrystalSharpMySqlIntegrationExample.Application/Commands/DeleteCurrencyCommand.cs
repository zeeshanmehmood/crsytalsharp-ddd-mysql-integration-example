using System;
using CrystalSharp.Application;
using CrystalSharpMySqlIntegrationExample.Application.Responses;

namespace CrystalSharpMySqlIntegrationExample.Application.Commands
{
    public class DeleteCurrencyCommand : ICommand<CommandExecutionResult<DeleteCurrencyResponse>>
    {
        public Guid GlobalUId { get; set; }
    }
}
