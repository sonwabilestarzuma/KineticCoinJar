using KineticCoinJar.IRepositories;
using KineticCoinJar.Repositories;
using Microsoft.VisualStudio.Services.Licensing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KineticCoinJar.ValidationRuleEngines
{
    public class MaxFluidOunceValidatorRule : IValidationRule<ICoin>
    {
        private readonly ICoinJar _coinJar;
        private readonly decimal _maxFluidOunces;

        public MaxFluidOunceValidatorRule(ICoinJar coinJar, decimal maxFluidOunces = 42)
        {
            _coinJar = coinJar;
            _maxFluidOunces = maxFluidOunces;
        }

        public OperationResult Validate(ICoin currentCoin)
        {
            var operationResult = new OperationResult();
            var currentOunces = _coinJar.GetTotalVolume();
            if ((currentOunces + currentCoin.Volume) > _maxFluidOunces)
            {
                operationResult.AddErrorMessage("CoinJar", $"Coin Jar can only hold {_maxFluidOunces} fluid ounces. Current total fluid ounces: {currentOunces:N}, Coin Fluid Ounces: {currentCoin.Volume:N}");
            }

            return operationResult;
        }
    }
}