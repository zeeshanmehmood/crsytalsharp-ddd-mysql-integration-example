using System;
using CrystalSharp.Application;
using CrystalSharpMySqlIntegrationExample.Application.ReadModels;

namespace CrystalSharpMySqlIntegrationExample.Application.Queries
{
    public class CurrencyDetailQuery : IQuery<QueryExecutionResult<CurrencyReadModel>>
    {
        public Guid GlobalUId { get; set; }
    }
}
