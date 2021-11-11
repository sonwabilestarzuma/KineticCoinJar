using KineticCoinJar.IRepositories;
using KineticCoinJar.Messages;
using KineticCoinJar.Repositories;
using KineticCoinJar.ValidationRuleEngines;
using MediatR;
using Microsoft.VisualStudio.Services.Licensing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KineticCoinJar.Handlers
{

    public class AddCoinCommandHandler : RequestHandler<AddCoinCommand, ValidationRuleEngines.OperationResult>
    {
        private readonly ICoinJar _dbcontext ;
        private readonly IValidationRuleEngine<ICoin> _coinJarValidatorRulesEngine;

        public AddCoinCommandHandler(ICoinJar dbcontext, IValidationRuleEngine<ICoin> coinJarValidatorRulesEngine)
        {
            _dbcontext = dbcontext;
            _coinJarValidatorRulesEngine = coinJarValidatorRulesEngine;
        }

        protected override ValidationRuleEngines.OperationResult Handle(AddCoinCommand command)
        {
            var result = new ValidationRuleEngines.OperationResult();

            try
            {
                ICoinFactory coinFactory = CoinFactoryProducer.GetFactory(command.Currency);

                ICoin coin = coinFactory.GetCoin(command.Amount);

                ValidationRuleEngines.OperationResult jarValidatorResult = _coinJarValidatorRulesEngine.Validate(coin);

                if (jarValidatorResult.HasErrors)
                {
                    result.AddErrorMessages(jarValidatorResult.GetErrorMessages());
                    return result;
                }

                _dbcontext.AddCoin(coin);
                return result;
            }
            catch (ApplicationException e)
            {
                result.AddErrorMessage(e.Key, e.Message);
            }

            return result;
        }
    }
}