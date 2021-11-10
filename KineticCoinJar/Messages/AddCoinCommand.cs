using KineticCoinJar.Enums;
using MediatR;
using Microsoft.VisualStudio.Services.Licensing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KineticCoinJar.Messages
{

    public class AddCoinCommand : IRequest<OperationResult>
    {
        public AddCoinCommand(CurrencyCode currency, decimal amount)
        {
            Currency = currency;
            Amount = amount;
        }

        public CurrencyCode Currency { get; }
        public decimal Amount { get; }
    }
}